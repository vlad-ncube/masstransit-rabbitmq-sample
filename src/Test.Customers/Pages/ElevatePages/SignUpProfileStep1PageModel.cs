using OpenQA.Selenium;
using Test.Customers.Pages;

internal interface ISignUpProfileStep1PageModel : IPageModel
{
    string Header { get; }
    string Skill { set; }
    string Experience { set; }
    string LastUsedMonth { set; }
    string LastUsedYear { set; }

    void SaveAndContinue();
}

namespace Test.Customers.Pages.ElevatePages
{
    public class SignUpProfileStep1PageModel : BasePageModel, ISignUpProfileStep1PageModel
    {
        // TODO: Vlad - think about where to take it from
        const string url = "http://localhost/Contractors/signup/steps?step=1";

        public string Header
        {
            get { return Driver.FindElement(By.TagName("h1")).Text; }
        }

        public string Skill
        {
            set { Driver.FindElement(By.ClassName("autoskill")).SendKeys(value); }
        }

        public string Experience
        {
            set { Driver.FindElement(By.XPath("//select[@data-bind='experience: experience']")).SendKeys(value); }
        }

        public string LastUsedMonth
        {
            set { Driver.FindElement(By.XPath("//select[@data-bind='month: lastUsedMonth']")).SendKeys(value); }
        }

        public string LastUsedYear
        {
            set { Driver.FindElement(By.XPath("//select[@data-bind='year: lastUsedYear']")).SendKeys(value); }
        }

        public SignUpProfileStep1PageModel(IWebDriver driver) : base(driver, url) { }

        public void SaveAndContinue()
        {
            Driver.FindElement(By.ClassName("btn-primary")).Click();
        }
    }
}