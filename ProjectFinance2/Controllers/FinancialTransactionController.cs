using Microsoft.AspNetCore.Mvc;
using ProjectFinance2.Interfaces;
using ProjectFinance2.Models;

namespace ProjectFinance2.Controllers
{
    public class FinancialTransactionController : Controller
    {

        private IFinancialTransactionRepository _financialTransactionRepository;
        private IAccountRepository _accountRepository;

        public FinancialTransactionController(IFinancialTransactionRepository financialTransactionRepository, IAccountRepository accountRepository)
        {
            _financialTransactionRepository = financialTransactionRepository;
            _accountRepository = accountRepository;
        }

        public ActionResult IndexCreateFinancialTransaction()
        {
            return View("Create");
        }

        public IActionResult Index()
        {
            IEnumerable<FinancialTransaction> financialTransactions = new List<FinancialTransaction>();

            try
            {
                financialTransactions = _financialTransactionRepository.GetFinancialTransactions();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(financialTransactions);
        }

        [Route("/CreateFinancialTransaction")]
        public IActionResult Create(FinancialTransaction financialTransaction)
        {
            if(ModelState.IsValid)
            try

            {
                _financialTransactionRepository.AddFinancialTransaction(financialTransaction);
                Account account = _accountRepository.GetAccountById(financialTransaction.DestinationAccount);
                    if (financialTransaction.Nature == 2)
                    {
                        account.CurrentBalance = (float)(Convert.ToDouble(account.CurrentBalance) - Convert.ToDouble(financialTransaction.Value));
                    }
                    else
                    {
                        account.CurrentBalance = (float)(Convert.ToDouble(account.CurrentBalance) + Convert.ToDouble(financialTransaction.Value));
                    }
                _financialTransactionRepository.AccountMovement(account.AccountId, account.CurrentBalance);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Index();
            return View("Index");
        }


    }
}
