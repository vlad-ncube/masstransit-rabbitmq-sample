using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;
using Test.Customers.Pages;

namespace Test.Customers.Steps
{
    [Binding]
    public class AddUserSteps
    {
        // TODO: vlad - refactor this
        UserPageModel userPage;

        [Given(@"I opened Add New User Page")]
        public void GivenIOpenedAddNewUserPage()
        {
            // TODO: vlad - refactor this: both page creation and path to phantom dir
            // TODO: vlad - also need to close the driver
            userPage = new UserPageModel(new PhantomJSDriver(@"..\..\..\src\Test.Customers"));
        }

        [When(@"I entered new user data")]
        public void WhenIEnteredNewUserData(Table table)
        {
            userPage.FirstName = table.Rows[0]["FirstName"];
            userPage.LastName = table.Rows[0]["LastName"];
            userPage.EmailAddress = table.Rows[0]["EmailAddress"];
            userPage.Age = table.Rows[0]["Age"];
            userPage.Location = table.Rows[0]["Location"];
        }

        [When(@"submited the page")]
        public void WhenSubmitedThePage()
        {
            userPage.Submit();
        }

        [Then(@"the result says the user ""(.*)"" has been added")]
        public void ThenTheResultSaysTheUserHasBeen(string userFirstName)
        {
            string resultMessage = userPage.ResultMessage;
            Assert.AreEqual(string.Format("User {0} has beed added", userFirstName), resultMessage);
        }

        [Then(@"new record about the user has been added to db")]
        public void ThenNewRecordAboutTheUserHasBeenAddedToDb()
        {
            //ScenarioContext.Current.Pending();
            // TODO: vlad - not here, just to test
            userPage.Driver.Quit();
        }
    }
}