using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCBCDemo.WebApplication.Utility.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAllowAnonymousAttribute : Attribute
    {
    }
}