using ProjectFinance2.Models;

namespace ProjectFinance2.Interfaces
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        void DeleteAccount(int accountId);
        List<Account> GetAccounts();

        Account GetAccountById(int accountId);
    }
}
