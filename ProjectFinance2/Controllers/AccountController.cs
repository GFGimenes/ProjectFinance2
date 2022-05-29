using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFinance2.Application.Repositories;
using ProjectFinance2.Interfaces;
using ProjectFinance2.Models;

namespace ProjectFinance2.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ActionResult IndexCreateAccount()
        {
            return View("CreateAccount");
        }

        [Route("/CreateAccount")]
        public ActionResult Create(Account account)
        {
            try
            {
                account.CurrentBalance = float.Parse(account.CurrentBalance.ToString());
                bool create = _accountRepository.AddAccount(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IndexCreateAccount();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Object htmlAttributes;
                
                bool delete = _accountRepository.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IndexCreateAccount();
        }

        public ActionResult AllAccounts()
        {
            IEnumerable<Account> accounts = new List<Account>();

            try
            {
               accounts = _accountRepository.GetAccounts();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(accounts);
        }

    }
}
