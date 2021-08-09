using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace OCBCDemo.WebApplication.Utility
{
    public class OCBCDIFactory
    { 
        private static IUnityContainer _Container = new UnityContainer();

        /// <summary>
        /// Create container according to Unity.config using singleton pattern
        /// </summary>
        static OCBCDIFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);  
            section.Configure(_Container, "OCBCContainer"); 
        }

        public static IUnityContainer GetContainer()
        {
            return _Container;
        }
    }
}