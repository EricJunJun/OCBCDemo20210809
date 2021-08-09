using OCBCDemo.Business.DataAccess;
using OCBCDemo.Business.Entity;
using OCBCDemo.Business.Interface;
using OCBCDemo.Business.Common.Utility.Pagination;
using OCBCDemo.Business.Common.Utility;
using OCBCDemo.WebApplication.Utility.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace OCBCDemo.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ITransactionService _TransactionService = null;
        Logger _logger = new Logger(typeof(HomeController));
        public HomeController(ITransactionService transactionService)
        {
            this._TransactionService = transactionService;
        }

        [HttpGet]
        [CustomAllowAnonymousAttribute]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAllowAnonymousAttribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        [CustomAllowAnonymousAttribute]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// transfer money
        /// </summary>
        /// <param name="accountId">the identifier of current user</param>
        /// <param name="recipientEmail">email is treated as the account id of recipient</param>
        /// <param name="transferAmount">money to transfer</param>
        /// <returns>if success, return current user latest account balance to UI</returns>
        [HttpPost]
        [CustomExceptionFilter]
        public ActionResult Transfer(string accountId, string recipientEmail, decimal transferAmount)
        {
            _logger.Info($"{accountId} transferred {transferAmount} to {recipientEmail} at {DateTime.Now}");
            var result = _TransactionService.Transfer(new Guid(accountId), recipientEmail, transferAmount);

            if (result.Contains("successfully"))
            {
                CurrentUser user = (CurrentUser)HttpContext.Session["CurrentUser"];
                user.Balance = Convert.ToDecimal(result.Split('|')[1]);
                HttpContext.Session["CurrentUser"] = user;
                return Json(new { HasError = false, Message = result.Split('|')[0], Balance = user.Balance.ToString() }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { HasError = true, Message = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// deposit money
        /// </summary>
        /// <param name="accountId">the identifier of current user</param>
        /// <param name="amount">money to deposit</param>
        /// <returns></returns>
        [HttpPost]
        [CustomExceptionFilter]
        public ActionResult Deposit(string accountId, decimal amount)
        {
            _logger.Info($"{accountId} deposited {amount} at {DateTime.Now}");

            //deposit the money base on user identifier
            var result = _TransactionService.Deposit(new Guid(accountId), amount);

            if (result.Contains("successfully"))
            {
                CurrentUser user = (CurrentUser)HttpContext.Session["CurrentUser"];
                user.Balance =Convert.ToDecimal(result.Split('|')[1]);
                HttpContext.Session["CurrentUser"] = user;
                return Json(new { HasError = false, Message = result.Split('|')[0], Balance = user.Balance.ToString() }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { HasError = true, Message = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Transaction history
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [CustomExceptionFilter]
        public ActionResult GetTransactionHistory(string searchString, int pageIndex = 1, int pageSize = 10)
        {
            Expression<Func<TransferHistory, bool>> funcWhere = c => true;

            if (!string.IsNullOrWhiteSpace(searchString))
                    funcWhere = c => c.RecipientEmail.Contains(searchString);

            Expression<Func<TransferHistory, DateTime?>> orderFunc = c => c.TransferDate;

            CustomPageModel<TransferHistory> pageResult = _TransactionService.QueryPage<TransferHistory, DateTime?>(funcWhere, pageSize, pageIndex, orderFunc, true);
            return PartialView("~/Views/Shared/_TransactionList.cshtml", pageResult);
        }
    }
}