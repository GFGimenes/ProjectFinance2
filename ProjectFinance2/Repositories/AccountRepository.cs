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
    public class AccountRepository : IAccountRepository
    {
        IConfiguration _configuration;

        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetConnectionString("ProjectFinanceConnection");
            return connection;
        }
        
        public bool AddAccount(Account account)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Accounts(Name, AccountNumber, CurrentBalance) VALUES( @Name, @AccountNumber, @CurrentBalance);";
                    con.Execute(query, account);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return true;
            }
        }

        public bool DeleteAccount(int accountId)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Accounts WHERE AccountId = @AccountId;";
                    con.Execute( query, new { accountId });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return true;
            }
        }

        public List<Account> GetAccounts()
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Accounts";
                    return con.Query<Account>(query).ToList();
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
