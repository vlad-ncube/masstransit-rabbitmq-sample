using OpenQA.Selenium;

namespace Test.Customers.Pages.ElevatePages
{
    internal interface IDashboardPageModel
    {
        string Title { get; }
    }

    namespace Test.Customers.Pages.ElevatePages
    {
        public class DashboardPageModel : BasePageModel, IDashboardPageModel
        {
            // TODO: Vlad - think about where to take it from
            const string url = "http://localhost/Contractors/login";

            public string Title
            {
                get { return Driver.Title; }
            }

            public DashboardPageModel(IWebDriver driver) : base(driver, url) { }
        }
    }
}