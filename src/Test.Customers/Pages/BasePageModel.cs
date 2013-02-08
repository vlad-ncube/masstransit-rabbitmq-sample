using System.Configuration;
using OpenQA.Selenium;
using Test.Customers.Steps;

namespace Test.Customers.Pages
{
    public abstract class BasePageModel
    {
        readonly IWebDriver driver;
        public IWebDriver Driver
        {
            get { return driver; }
        }

        protected virtual string Path
        {
            get { return ""; }
        }

        public BasePageModel(IWebDriver driver)
        {
            this.driver = driver;

            string url = ConfigurationManager.AppSettings["MassTransitUrl"] + Path;
            if (this.driver.Url.ToLower() != url.ToLower())
            {
                driver.Navigate().GoToUrl(url);
            }
        }

        // TODO: vlad - remove dependency from BaseSteps - create a kind of Context
        public BasePageModel():this (BaseSteps.Container.Resolve<IWebDriver>()){}
    }
}