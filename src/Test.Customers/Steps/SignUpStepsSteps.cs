using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Test.Customers.Pages;

namespace Test.Customers.Steps
{
    [Binding]
    public class SignUpStepsSteps : BaseSteps
    {
        // use one model for different steps - just for tests
        ISignUpStep1PageModel signupPage;

        [Given(@"I have page opened")]
        public void GivenIHavePageOpened()
        {
            signupPage = Container.Resolve<ISignUpStep1PageModel>();
        }
        
        [When(@"I press Next button two times")]
        public void WhenIPressNextButtonTwoTimes()
        {
            signupPage.Next();
            signupPage.Next();
        }
        
        [Then(@"the result should contain header with text ""(.*)""")]
        public void ThenTheResultShouldContainHeaderWithText(string expectedStepHeader)
        {
            string resultStepHeader = signupPage.StepHeader;
            Assert.AreEqual(expectedStepHeader, resultStepHeader);
        }
    }
}