using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Test.Customers.Pages;

namespace Test.Customers.Steps
{
    [Binding]
    public class AddUserSteps : BaseSteps
    {
        IUserPageModel userPage;

        [Given(@"I opened Add New User Page")]
        public void GivenIOpenedAddNewUserPage()
        {
            userPage = Container.Resolve<IUserPageModel>();
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
            // add db logic here
        }
    }
}