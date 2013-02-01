using Domain.DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using TechTalk.SpecFlow;
using Test.Customers.Pages.ElevatePages;

namespace Test.Customers.Steps.ElevateSteps
{
    [Binding]
    public class ElevateContractorSignUpStepsSteps : BaseSteps
    {
        ILoginPageModel loginPage;

        [Given(@"I have sign in page opened")]
        public void GivenIHaveSignInPageOpened()
        {
            loginPage = Container.Resolve<ILoginPageModel>();
        }

        [When(@"I enter my Email = '(.*)' and Password = '(.*)'")]
        public void WhenIEnterMyEmailAndPassword(string email, string password)
        {
            loginPage.Email = email;
            loginPage.Password = password;
            loginPage.SignIn();
        }

        [Then(@"my dashboard is opened and its title is '(.*)'")]
        public void ThenMyDashboardIsOpenedAndItsTitleIs(string title)
        {
            IDashboardPageModel dashboardPage = Container.Resolve<IDashboardPageModel>();
            Assert.AreEqual(title, dashboardPage.Title);
        }

        [When(@"I manually enter signup steps url = '(.*)'")]
        public void WhenIManuallyEnterSignupStepsUrl(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"profile's Choose password page is opened")]
        public void ThenProfileSChoosePasswordPageIsOpened()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it says '(.*)'ve completed signing up\.'")]
        public void ThenItSaysVeCompletedSigningUp_(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press Continue")]
        public void WhenIPressContinue()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"profile's Technical skills page is opened")]
        public void ThenProfileSTechnicalSkillsPageIsOpened()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter skills:")]
        public void WhenIEnterSkills(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Press Save and Continue button")]
        public void WhenPressSaveAndContinueButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"profile's Work experience page is opened")]
        public void ThenProfileSWorkExperiencePageIsOpened()
        {
            ScenarioContext.Current.Pending();
        }

    }
}