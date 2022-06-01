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
            return View("Create");
        }

        [Route("/CreateAccount")]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
            try
            {
                account.CurrentBalance = float.Parse(account.CurrentBalance.ToString());
                _accountRepository.AddAccount(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            }
            Index();
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _accountRepository.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Index();
            return View("Index");
        }

        public ActionResult Index()
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
