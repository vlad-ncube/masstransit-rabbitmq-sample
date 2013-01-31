namespace Test.Customers.Pages
{
    interface ISignUpStep1PageModel
    {
        string StepHeader { get; }

        void Next();

        void BrowserBack();

        void BrowserForward();
    }
}