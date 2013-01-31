using OpenQA.Selenium;

namespace Test.Customers.Pages
{
    public class SignUpStep1PageModel : BasePageModel, ISignUpStep1PageModel
    {
        // TODO: Vlad - think about where to take it from
        const string url = "http://localhost:1825/SignUpSteps";

        public string StepHeader
        {
            get { return Driver.FindElement(By.Id("stepHeader")).Text; }
        }

        public SignUpStep1PageModel(IWebDriver driver) : base(driver, url) { }

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