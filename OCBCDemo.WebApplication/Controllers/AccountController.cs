using OCBCDemo.Business.Entity;
using OCBCDemo.Business.Interface;
using OCBCDemo.Business.DataAccess;
using OCBCDemo.WebApplication.Utility;
using OCBCDemo.WebApplication.Utility.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCBCDemo.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _UserService = null;
        private ITransactionService _TransactionService = null;

        //Inject IUserService and ITransactionService instance via IOC container to create AccountController instance
        public AccountController(IUserService userService, ITransactionService transactionService)
        {
            this._UserService = userService;
            this._TransactionService = transactionService;
        }

        #region Login
        [HttpGet]
        [CustomAllowAnonymousAttribute]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [CustomAllowAnonymousAttribute]
        public ActionResult Login(string name, string password, string verify)
        {
            if (!string.Equals(verify, HttpContext.Session["CheckCode"].ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                ModelState.AddModelError("failed", "Invalid verification code.");
                return View();
            }

            var currentUser = _UserService.GetUserInfoByNameAndPassword(name.Trim(), password.Trim());
            //Verify user name and password
            if (currentUser != null && name.Equals(currentUser.Name) && password.Equals(currentUser.Password))
            {
                HttpContext.Session["CurrentUser"] = currentUser;
                return base.Redirect("/Home/Index");
            }
            else
            {
                ModelState.AddModelError("failed", "Invalid user name or password.");
                return View();
            }
        }

        #endregion

        #region Register
        [HttpGet]
        [CustomAllowAnonymousAttribute]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// save registration info and redirect to home page
        /// </summary>
        /// <param name="registerDetails">registration detail</param>
        /// <returns>retrun to home page if success</returns>
        [HttpPost]
        [CustomAllowAnonymousAttribute]
        [CustomExceptionFilter]
        public ActionResult SaveRegistrationDetail(RegisterViewModel registrationInfo)
        {
            if (ModelState.IsValid)
            {
                //step1: initial the user entity to save into database
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = registrationInfo.Name,
                    Email = registrationInfo.Email,
                    PhoneNumber = registrationInfo.PhoneNumber,
                    Password = registrationInfo.Password,
                    Balance = 0,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    IsDeleted = false
                };

                //step2: save into database
                var result = _UserService.Insert<User>(user);

                //step3: direct to home page if user successfully saved into database
                if (result != null)
                {
                    var currentUser = new CurrentUser()
                    {
                        AccountId = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Password = user.Password,
                        Balance = 0,
                        LastLoginDate = DateTime.Now
                    };
                    HttpContext.Session["CurrentUser"] = currentUser;
                    return View("/Home/Index", currentUser);
                }
                else
                    //stay in register page and display the error message returned from server
                    return View("Register", registrationInfo);
            }
            else
                //if the validation fails, return the model with errors to the view so can display the error message
                // ModelState.AddModelError("failed", ModelState.);
                return View("Register", registrationInfo);
        }

        #endregion


        /// <summary>
        /// Create and save the verification code into response
        /// </summary>
        [CustomAllowAnonymousAttribute]
        public void VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;
            bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);
            base.Response.ContentType = "image/gif";
        }


        [HttpPost]
        public ActionResult Logout()
        {
            #region Set cookie as expired
            HttpCookie myCookie = HttpContext.Request.Cookies["CurrentUser"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddMinutes(-1);
                HttpContext.Response.Cookies.Add(myCookie);
            }

            #endregion Cookie

            #region Clear session
            HttpContext.Session["CurrentUser"] = null;
            HttpContext.Session.Remove("CurrentUser");
            HttpContext.Session.Clear();
            HttpContext.Session.RemoveAll();
            HttpContext.Session.Abandon();
            #endregion Session

            return RedirectToAction("Login", "Account"); ;
        }
    }
}