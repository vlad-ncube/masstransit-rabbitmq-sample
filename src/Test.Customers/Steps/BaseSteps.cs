using Castle.MicroKernel.Registration;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;
using Castle.Windsor;
using Test.Customers.Pages;

namespace Test.Customers.Steps
{
    [Binding]
    public class BaseSteps
    {
        public static WindsorContainer Container;

        [BeforeTestRun]
        public static void TestsSetup()
        {
            Container = new WindsorContainer();

            // TODO: vlad - register all classes which implement IPageModel
            Container.Register(Component.For<IUserPageModel>().ImplementedBy<UserPageModel>());
            
            // TODO: vlad - refactor the way phantom being run
            IWebDriver driver = new PhantomJSDriver();
            Container.Register(Component.For<IWebDriver>().Instance(driver)); 
        }

        [AfterTestRun]
        public static void TestsCleanup()
        {
            Container.Resolve<IWebDriver>().Quit();
        }
    }
}