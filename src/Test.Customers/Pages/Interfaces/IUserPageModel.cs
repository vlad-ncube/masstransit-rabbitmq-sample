﻿namespace Test.Customers.Pages.Interfaces
{
    internal interface IUserPageModel : IPageModel
    {
        string FirstName { set; }
        string LastName { set; }
        string EmailAddress { set; }
        string Age { set; }
        string Location { set; }
        string ResultMessage { get; }

        void Submit();
    }
}