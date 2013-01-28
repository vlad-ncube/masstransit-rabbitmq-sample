using OpenQA.Selenium;

namespace Test.Customers.Pages
{
    class UserPageModel : BasePageModel
    {
        // TODO: Vlad - think about where to take it from
        const string url = "http://localhost:1825/";

        public string FirstName
        {
            set { Driver.FindElement(By.Id("FirstName")).SendKeys(value); }
        }

        public string LastName
        {
            set { Driver.FindElement(By.Id("LastName")).SendKeys(value); }
        }

        public string EmailAdress
        {
            set { Driver.FindElement(By.Id("EmailAddress")).SendKeys(value); }
        }

        public string Age
        {
            set { Driver.FindElement(By.Id("Age")).SendKeys(value); }
        }

        public string Location
        {
            set { Driver.FindElement(By.Id("Location")).SendKeys(value); }
        }

        public string ResultMessage
        {
            get { return Driver.FindElement(By.Id("ResultMessage")).Text; }
        }

        public UserPageModel(IWebDriver driver) : base(driver, url){}

        public void Submit()
        {
            Driver.FindElement(By.Id("Submit")).Submit();
        }
    }
}