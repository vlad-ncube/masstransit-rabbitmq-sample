using System;
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

        public BasePageModel(IWebDriver driver, string url)
        {
            this.driver = driver;

            if (this.driver.Url != url)
            {
                driver.Navigate().GoToUrl(url);
            }
        }
    }
}