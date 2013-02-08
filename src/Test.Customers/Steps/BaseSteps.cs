using Castle.MicroKernel.Registration;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Repositories;
using TechTalk.SpecFlow;
using Castle.Windsor;
using Test.Customers.Pages.Interfaces;

namespace Test.Customers.Steps
{
    [Binding]
    public class BaseSteps
    {
        static WindsorContainer container;

        public static WindsorContainer Container
        {
            get { return container; }
        }

        [BeforeTestRun]
        public static void TestsSetup()
        {
            ConfigureContainer();
        }

        static void ConfigureContainer()
        {
            container = new WindsorContainer();

            container.Register(AllTypes.FromThisAssembly().BasedOn<IPageModel>().WithService.FirstInterface());

            // TODO: vlad - refactor the way phantom being run
            IWebDriver driver = new PhantomJSDriver();
            container.Register(Component.For<IWebDriver>().Instance(driver));

            container.Register(Component.For<IRepository>().ImplementedBy<MongoRepository>()); // TODO: vlad - can we get it from a config?
        }

        [AfterTestRun]
        public static void TestsCleanup()
        {
            container.Resolve<IWebDriver>().Quit();
        }

        [BeforeScenario("@cleanDB")]
        public static void CleanDb()
        {
            // TODO: vlad - refactor repository
            IRepository repository = Container.Resolve<IRepository>();
            repository.DeleteUsers();
        }
    }
}