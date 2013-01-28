using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Repositories;
using Domain.DomainObjects;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Test.Customers.Pages;

namespace Test.Customers
{
    [TestClass]
    public class TestHomeController
    {
        static Process serviceProcess;
        static WindsorContainer container;

        static TestHomeController()
        {
            container = new WindsorContainer();
            container.Register(Component.For<IRepository>().ImplementedBy<MongoRepository>()); // TODO: vlad - can we get it from a config?
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            serviceProcess = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "service")
                ?? Process.Start(@"..\..\..\..\output\service\Service.exe");
        }
        
        [TestInitialize]
        public void TestInitialize()
        {
            // TODO: vlad - get it by DI
            IRepository repository = container.Resolve<IRepository>();
            repository.DeleteUsers(); // clears db before each test (only users for now)
        }

        [TestMethod]
        public void Index_ValidData_Success()
        {
            // TODO: Vlad - use DI here
            UserPageModel userPage = new UserPageModel(new PhantomJSDriver());

            // fill all the fields
            string userFirstName = "Test First Name";
            userPage.FirstName = userFirstName;
            userPage.LastName = "Test Last Name";
            userPage.EmailAdress = "Test Email Address";
            userPage.Age = "99";
            userPage.Location = "Test Location";

            // submit
            userPage.Submit();

            // check result webpage
            string resultMessage = userPage.ResultMessage;
            Assert.AreEqual(string.Format("User {0} has beed added", userFirstName), resultMessage);

            // check db
            System.Threading.Thread.Sleep(5000); // TODO: vlad - make it in a right way
            IRepository repository = container.Resolve<IRepository>();
            User dbUser = repository.GetUserByName(userFirstName);
            Assert.AreEqual(99, dbUser.Age);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            serviceProcess.Kill();
        }
    }
}