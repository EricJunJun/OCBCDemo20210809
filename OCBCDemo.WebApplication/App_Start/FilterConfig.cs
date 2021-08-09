using OCBCDemo.WebApplication.Utility.Filters;
using System.Web;
using System.Web.Mvc;

namespace OCBCDemo.WebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CustomActionFilterAttribute());  //3.全局注册，就对项目中的所有方法都生效
            filters.Add(new CustomExceptionFilterAttribute()); //整个项目中，如有异常，都去捕捉处理；
            filters.Add(new CustomAuthorizationFilterAttribute());
        }
    }
}
