using OpenQA.Selenium;
using Test.Customers.Pages;

internal interface ISignUpProfileStep0PageModel : IPageModel
{
    string Header { get; }

    void Continue();
}

namespace Test.Customers.Pages.ElevatePages
{
    public class SignUpProfileStep0PageModel : BasePageModel, ISignUpProfileStep0PageModel
    {
        // TODO: Vlad - think about where to take it from
        const string url = "http://localhost/Contractors/signup/steps?step=0";

        public string Header
        {
            get { return Driver.FindElement(By.TagName("h1")).Text; }
        }

        public SignUpProfileStep0PageModel(IWebDriver driver) : base(driver, url) { }

        public void Continue()
        {
            Driver.FindElement(By.ClassName("btn-primary")).Click();
        }
    }
}