using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Repositories;
using Domain.DomainObjects;

namespace Test.Customers
{
    [TestClass]
    public class TestHomeController
    {
        private IWebDriver driver;
        private static Process serviceProcess;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            serviceProcess = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "service")
                ?? Process.Start(@"..\..\..\..\output\service\Service.exe");
        }
        
        [TestInitialize]
        public void TestInitialize()
        {
            MongoRepository.DeleteUsers(); // clear db before each test (only users for now)
            driver = new PhantomJSDriver();
        }

        [TestMethod]
        public void Index_ValidData_Success()
        {
            driver.Navigate().GoToUrl("http://localhost:1825/");

            // fill all the fields
            string userFirstName = "Test First Name";
            driver.FindElement(By.Id("FirstName")).SendKeys(userFirstName);
            driver.FindElement(By.Id("LastName")).SendKeys("Test Last Name");
            driver.FindElement(By.Id("EmailAddress")).SendKeys("Test Email Address");
            driver.FindElement(By.Id("Age")).SendKeys("99");
            driver.FindElement(By.Id("Location")).SendKeys("Test Location");

            // submit
            driver.FindElement(By.Id("Submit")).Submit();

            // check result webpage
            string resultMessage = driver.FindElement(By.Id("ResultMessage")).Text;
            Assert.AreEqual(string.Format("User {0} has beed added", userFirstName), resultMessage);

            // check db
            System.Threading.Thread.Sleep(5000); // TODO: vlad - make it in a right way
            User dbUser = MongoRepository.GetUserByName(userFirstName);
            Assert.AreEqual(99, dbUser.Age);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            serviceProcess.Kill();
        }
    }
}