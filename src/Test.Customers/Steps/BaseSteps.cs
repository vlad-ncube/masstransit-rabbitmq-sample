using Castle.MicroKernel.Registration;
using Domain.DomainObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using MasstransitSpike.Core.Repositories;
using TechTalk.SpecFlow;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Test.Customers.Pages.Interfaces;
using System;

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

            container.Register(AllTypes.FromThisAssembly().BasedOn<IPageModel>().WithServiceFirstInterface());

            // TODO: vlad - refactor the way phantom being run
            IWebDriver driver = new PhantomJSDriver();
            container.Register(Component.For<IWebDriver>().Instance(driver));

            container.Install(Configuration.FromAppConfig());
        }

        [AfterTestRun]
        public static void TestsCleanup()
        {
            container.Resolve<IWebDriver>().Quit();
        }

        [BeforeScenario("@cleanDB")]
        public static void CleanDb()
        {
            container.Resolve<IUserRepository>().DeleteAll();
        }
    }
}