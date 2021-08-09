using Microsoft.Practices.Unity.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OCBCDemo.Business.Interface;
using OCBCDemo.Business.Services;
using OCBCDemo.WebApplication;
using OCBCDemo.WebApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Unity;

namespace OCBCDemo.WebApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public IUserService _UserService;
        public ITransactionService _TransactionService;
        private static IUnityContainer _Container = new UnityContainer();

        public HomeControllerTest()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\Unity.config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            section.Configure(_Container, "OCBCContainer");
            _TransactionService = _Container.Resolve<ITransactionService>();
        }

        [TestMethod]
        public void DepositTest()
        {
            // Act
            string result = _TransactionService.Deposit(new Guid("C890304F-1C7F-405B-9CDB-0DF2074D3C35"),100);

            // Assert
            Assert.IsTrue(result.Split('|')[0].Contains("successfully"));
        }


        [TestMethod]
        public void TransferTest()
        {
            // Act
            string result = _TransactionService.Transfer(new Guid("C890304F-1C7F-405B-9CDB-0DF2074D3C35"), "1123@gmail.com", 100);

            // Assert
            Assert.IsTrue(result.Split('|')[0].Contains("successfully"));
        }
    }
}
