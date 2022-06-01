using Dapper;
using Microsoft.Extensions.Configuration;
using ProjectFinance2.Interfaces;
using ProjectFinance2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace ProjectFinance2.Application.Repositories
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        IConfiguration _configuration;

        public FinancialTransactionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetConnectionString("ProjectFinanceConnection");
            return connection;
        }
        
        public void AddFinancialTransaction(FinancialTransaction financialTransaction)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO FinancialTransaction(DestinationAccount, Description, Value, Nature) VALUES( @DestinationAccount, @Description, @Value, @Nature);";
                    con.Execute(query, financialTransaction);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void AccountMovement(int accountId, float value)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = $@"UPDATE Accounts 
                                    SET CurrentBalance = @value
                                    WHERE AccountId = @accountId";
                    con.Execute( query, new { accountId, value });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public List<FinancialTransaction> GetFinancialTransactions()
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM FinancialTransaction";
                    return con.Query<FinancialTransaction>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }

    }
}
