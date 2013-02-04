using OpenQA.Selenium;
using Test.Customers.Pages;

internal interface ISignUpProfileStep2PageModel : IPageModel
{
    string Header { get; }
}

namespace Test.Customers.Pages.ElevatePages
{
    public class SignUpProfileStep2PageModel : BasePageModel, ISignUpProfileStep2PageModel
    {
        // TODO: Vlad - think about where to take it from
        const string url = "http://localhost/Contractors/signup/steps?step=2";

        public string Header
        {
            get { return Driver.FindElement(By.TagName("h1")).Text; }
        }

        public SignUpProfileStep2PageModel(IWebDriver driver) : base(driver, url) { }
    }
}