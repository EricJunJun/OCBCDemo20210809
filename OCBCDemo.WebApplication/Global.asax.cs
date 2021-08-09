using OCBCDemo.WebApplication.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OCBCDemo.WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ///把自定义的控制器工厂给设置到框架中去
            ControllerBuilder.Current.SetControllerFactory(new OCBCControllerFactory());
        }

        /// <summary>
        ///只要是响应不是200,就能被这里捕捉到；可以捕捉到比如非法路径的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception excetion = Server.GetLastError();
            Response.Write("System is Error....");
            Server.ClearError();
        }
    }
}
