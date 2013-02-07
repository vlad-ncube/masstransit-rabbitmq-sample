using System.Configuration;
using OpenQA.Selenium;

namespace Test.Customers.Pages
{
    public class BasePageModel
    {
        readonly IWebDriver driver;
        public IWebDriver Driver
        {
            get { return driver; }
        }

        public BasePageModel(IWebDriver driver, string path)
        {
            this.driver = driver;

            string url = ConfigurationManager.AppSettings["MassTransitUrl"] + path;
            if (this.driver.Url.ToLower() != url.ToLower())
            {
                driver.Navigate().GoToUrl(url);
            }
        }
    }
}