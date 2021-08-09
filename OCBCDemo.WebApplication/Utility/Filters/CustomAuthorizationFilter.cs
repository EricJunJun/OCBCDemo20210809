using OCBCDemo.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCBCDemo.WebApplication.Utility.Filters
{
    public class CustomAuthorizationFilterAttribute : FilterAttribute, IAuthorizationFilter
    {

        private string _LoginUrl = null;
        public CustomAuthorizationFilterAttribute(string loginUrl = "~/Account/Login")
        {
            this._LoginUrl = loginUrl;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;

            #region Check if action or controller is maked CustomAllowAnonymousAttribute, if yes, return directly
            if (filterContext.ActionDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute), true))
                return;
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute), true))
                return;
            #endregion

            //Check if session is null
            if (httpContext.Session["CurrentUser"] == null || !(httpContext.Session["CurrentUser"] is CurrentUser))
            {
                if (httpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            DebugMessage = "session expired",
                            RetValue = ""
                        }
                    };
                }
                else
                {
                    //Redirect to the login page
                    httpContext.Session["CurrentUrl"] = httpContext.Request.Url.AbsoluteUri;
                    filterContext.Result = new RedirectResult(this._LoginUrl);
                }
            }
            else
            {
                //Save session
                CurrentUser user = (CurrentUser)httpContext.Session["CurrentUser"];
                return;
            }
        }
    }
}