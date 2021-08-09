using OCBCDemo.Business.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCBCDemo.WebApplication.Utility.Filters
{
    public class CustomExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// Action triggered when exception occurred
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            Logger _logger = new Logger(typeof(CustomExceptionFilterAttribute));
            _logger.Error($"Error occurred at {DateTime.Now} with error message: {filterContext.Exception.Message}");

            if (!filterContext.ExceptionHandled)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())//Return error message
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            DebugMessage = filterContext.Exception.Message,
                            RetValue = "",
                            PromptMsg = "Error occurred, please contact the administrator for help."
                        }
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult()//Redirct to the error page
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                    };
                }
                filterContext.ExceptionHandled = true;//Make exception as handled
            }
        }
    }
}