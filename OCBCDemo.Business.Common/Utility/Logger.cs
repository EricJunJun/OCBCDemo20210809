using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Common.Utility
{
    public class Logger
    {
        private ILog loger = null;

        static Logger()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CfgFiles\\log4net.config")));
            ILog Log = LogManager.GetLogger(typeof(Logger));
        }


        public Logger(Type type)
        {
            loger = LogManager.GetLogger(type);
        }

        public void Error(string msg = "Error occurred", Exception ex = null)
        {
            loger.Error(msg, ex);
        }

        public void Warn(string msg)
        {
            loger.Warn(msg);
        }

        public void Info(string msg)
        {
            loger.Info(msg);
        }

        public void Debug(string msg)
        {
            loger.Debug(msg);
        }

    }
}