using OCBCDemo.Business.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace OCBCDemo.Business.Common.Utility.AOP
{
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        Logger _logger = new Logger(typeof(LogAfterBehavior));

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {

            _logger.Info($" LogBeforeBehavior Start--{input.MethodBase.Name} 执行之前。。。。");
            IMethodReturn methodReturn = getNext().Invoke(input, getNext);
            _logger.Info($" LogBeforeBehavior End--{input.MethodBase.Name} 执行之后。。。。");

            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}