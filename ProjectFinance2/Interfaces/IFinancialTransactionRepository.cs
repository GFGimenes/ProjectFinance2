using ProjectFinance2.Models;

namespace ProjectFinance2.Interfaces
{
    public interface IFinancialTransactionRepository
    {
        void AddFinancialTransaction(FinancialTransaction financialTransaction);
        void AccountMovement(int accountId, float value);
        List<FinancialTransaction> GetFinancialTransactions();
    }
}
