using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace OCBCDemo.WebApplication.Utility
{
    public class OCBCControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Create controller instance with params via IOC container
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IUnityContainer container = OCBCDIFactory.GetContainer();
            object controllerInstance = container.Resolve(controllerType); 
            return (IController)controllerInstance;
        }
    }
}