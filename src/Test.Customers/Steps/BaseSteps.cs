using Castle.MicroKernel.Registration;
using Domain.DomainObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Repositories;
using Repositories.MongoRepository;
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

            container.Register(AllTypes.FromThisAssembly().BasedOn<BaseMongoRepository<IEntity>>()); // TODO: vlad - can we get it from a config?
        }

        [AfterTestRun]
        public static void TestsCleanup()
        {
            container.Resolve<IWebDriver>().Quit();
        }

        [BeforeScenario("@cleanDB")]
        public static void CleanDb()
        {
            var repositories = Container.ResolveAll<IRepository<IEntity>>();
            foreach (var repository in repositories)
            {
                repository.DeleteAll();
            }
        }
    }
}