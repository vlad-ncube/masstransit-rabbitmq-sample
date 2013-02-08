using OpenQA.Selenium;
using Test.Customers.Pages.Interfaces;

namespace Test.Customers.Pages
{
    public class UserPageModel : BasePageModel, IUserPageModel
    {
        public string FirstName
        {
            set { Driver.FindElement(By.Id("FirstName")).SendKeys(value); }
        }

        public string LastName
        {
            set { Driver.FindElement(By.Id("LastName")).SendKeys(value); }
        }

        public string EmailAddress
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

        public void Submit()
        {
            Driver.FindElement(By.Id("Submit")).Submit();
        }
    }
}