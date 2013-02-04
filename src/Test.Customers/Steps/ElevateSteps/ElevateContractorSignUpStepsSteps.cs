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
        ISignUpProfileStep0PageModel step0Page;
        ISignUpProfileStep1PageModel step1Page;

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

        [When(@"I manually go to signup step 0")]
        public void WhenIManuallyEnterSignupStepsUrl()
        {
            step0Page = Container.Resolve<ISignUpProfileStep0PageModel>();
        }

        [Then(@"profile step0 page is opened with header '(.*)'")]
        public void ThenProfileChoosePasswordPageIsOpenedWithHeader(string pageHeader)
        {
            Assert.AreEqual(pageHeader, step0Page.Header);
        }
        
        [When(@"I press Continue")]
        public void WhenIPressContinue()
        {
            step0Page.Continue();
        }

        [Then(@"profile step1 page is opened with header '(.*)'")]
        public void ThenProfileSTechnicalSkillsPageIsOpened(string pageHeader)
        {
            step1Page = Container.Resolve<ISignUpProfileStep1PageModel>();
            Assert.AreEqual(pageHeader, step1Page.Header);
        }

        [When(@"I enter skills:")]
        public void WhenIEnterSkills(Table table)
        {
            step1Page.Skill = table.Rows[0]["Skill"];
            step1Page.Experience = table.Rows[0]["Experience"];
            step1Page.LastUsedMonth = table.Rows[0]["LastUsedMonth"];
            step1Page.LastUsedYear = table.Rows[0]["LastUsedYear"];
        }

        [When(@"Press Save and Continue button")]
        public void WhenPressSaveAndContinueButton()
        {
            step1Page.SaveAndContinue();
        }

        [Then(@"profile step2 page is opened with header '(.*)'")]
        public void ThenProfileSWorkExperiencePageIsOpened(string pageHeader)
        {
            ISignUpProfileStep2PageModel step2Page = Container.Resolve<ISignUpProfileStep2PageModel>();
            Assert.AreEqual(pageHeader, step2Page.Header);
        }
    }
}