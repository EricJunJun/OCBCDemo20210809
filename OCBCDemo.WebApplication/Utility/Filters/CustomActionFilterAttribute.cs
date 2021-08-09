using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCBCDemo.WebApplication.Utility.Filters
{
    /// <summary>
    /// Create custom action filter
    /// </summary>
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Console.WriteLine($"CustomActionFilterAttribute.OnActionExecuting...");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Console.WriteLine($"CustomActionFilterAttribute.OnActionExecuted...");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Console.WriteLine($"CustomActionFilterAttribute.OnResultExecuting...");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Console.WriteLine($"CustomActionFilterAttribute.OnResultExecuted...");
        }
    }


    /// <summary>
    ///Create action filter by extend interface
    /// </summary>
    //public class CustomIActionFilterAttribute : FilterAttribute, IActionFilter
    //{ 
    //    public void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        Console.WriteLine("Custom01ActionFilterAttribute.OnActionExecuting");
    //    }

    //    public void OnActionExecuted(ActionExecutedContext filterContext)
    //    {
    //        Console.WriteLine("Custom01ActionFilterAttribute.OnActionExecuted");
    //    }
    //}
}