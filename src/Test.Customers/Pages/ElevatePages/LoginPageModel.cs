using OpenQA.Selenium;

namespace Test.Customers.Pages.ElevatePages
{
    internal interface ILoginPageModel : IPageModel
    {
        string Email { set; }
        string Password { set; }

        void SignIn();
    }

    public class LoginPageModel : BasePageModel, ILoginPageModel
    {
        // TODO: Vlad - think about where to take it from
        //const string url = "http://localhost/Contractors/login";
        const string url = "https://app.elevatedirect.com/Contractors/login";

        public string Email
        {
            set { Driver.FindElement(By.Id("Email")).SendKeys(value); }
        }

        public string Password
        {
            set { Driver.FindElement(By.Id("Password")).SendKeys(value); }
        }

        public LoginPageModel(IWebDriver driver) : base(driver, url) { }

        public void SignIn()
        {
            Driver.FindElement(By.ClassName("btn")).Click();
        }
    }
}