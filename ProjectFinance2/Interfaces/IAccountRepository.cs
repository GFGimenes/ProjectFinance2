using ProjectFinance2.Models;

namespace ProjectFinance2.Interfaces
{
    public interface IAccountRepository
    {
        bool AddAccount(Account account);
        bool DeleteAccount(int accountId);
        List<Account> GetAccounts();
    }
}
