using OCBCDemo.Business.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace OCBCDemo.Business.Common.Utility.AOP
{
    public class LogAfterBehavior : IInterceptionBehavior
    {
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        Logger _logger = new Logger(typeof(LogAfterBehavior));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            _logger.Info($"LogAfterBehavior Start-{input.MethodBase.Name} 执行之前。。。。");
            IMethodReturn methodReturn = getNext()(input, getNext);
            _logger.Info($"LogAfterBehavior End-{input.MethodBase.Name} 执行之后。。。。");

            return methodReturn;
        }
    }
}