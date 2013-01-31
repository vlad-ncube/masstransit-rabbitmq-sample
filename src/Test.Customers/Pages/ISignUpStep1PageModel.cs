namespace Test.Customers.Pages
{
    interface ISignUpStep1PageModel : IPageModel
    {
        string StepHeader { get; }

        void Next();

        void BrowserBack();

        void BrowserForward();
    }
}