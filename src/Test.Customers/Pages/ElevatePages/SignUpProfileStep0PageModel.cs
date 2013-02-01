using OpenQA.Selenium;

internal interface ISignUpProfileStep0PageModel
{
    //string Email { set; }
    //string Password { set; }

    //void Continue();
}

namespace Test.Customers.Pages.ElevatePages
{
    public class SignUpProfileStep0PageModel : BasePageModel, ISignUpProfileStep0PageModel
    {
        // TODO: Vlad - think about where to take it from
        const string url = "http://localhost/Contractors/login";

        public SignUpProfileStep0PageModel(IWebDriver driver) : base(driver, url) { }
    }
}