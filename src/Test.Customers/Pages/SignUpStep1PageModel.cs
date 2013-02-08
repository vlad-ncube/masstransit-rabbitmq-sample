using OpenQA.Selenium;
using Test.Customers.Pages.Interfaces;

namespace Test.Customers.Pages
{
    public class SignUpStep1PageModel : BasePageModel, ISignUpStep1PageModel
    {
        protected override string Path
        {
            get { return "SignUpSteps"; }
        }

        public string StepHeader
        {
            get { return Driver.FindElement(By.Id("stepHeader")).Text; }
        }

        public void Next()
        {
            Driver.FindElement(By.Id("sbmNext")).Click();
        }

        public void BrowserBack()
        {
            Driver.Navigate().Back();
        }

        public void BrowserForward()
        {
            Driver.Navigate().Forward();
        }
    }
}