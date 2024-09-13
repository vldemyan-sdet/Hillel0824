namespace AtataDemoQA
{
    public sealed class ButtonsTest : UITestFixture
    {
        [Test, Description("Verify Click Me button"), Retry(2)]
        [Category("UI")]
        public void ClickButtonTest() =>
            Go.To<ButtonsPage>().
                PageUrl.Should.Be("https://demoqa.com/buttons").
                ClickMe.Click().
                DinamicClickMessage.Should.Be("You have done a dynamic click").
                DoubleClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Double Click Me button"), Retry(2)]
        [Category("UI")]
        public void DoubleClickButtonTest() =>
            Go.To<ButtonsPage>().
                PageUrl.Should.Be("https://demoqa.com/buttons").
                DoubleClickMe.DoubleClick().
                DoubleClickMessage.Should.Be("You have done a double click").
                DinamicClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public void RigthClickButtonTest() =>
            Go.To<ButtonsPage>().
                PageUrl.Should.Be("https://demoqa.com/buttons").
                RigthClickMe.RightClick().
                RightClickMessage.Should.Be("You have done a right click").
                DoubleClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify that 'Click Me' button is enabled")]
        public void VerifyClickButtonIsEnabled() =>
            Go.To<ButtonsPage>().
                ClickMe.Should.BeEnabled();

        [Test, Description("Verify Right Click button "), Retry(2)]
        public void VerifyClickOfRightClickButton() =>
            Go.To<ButtonsPage>().
               RigthClickMe.RightClick().
               RigthClickMe.Should.BeFocused();

        [Test, Description("Verify H1 Buttons is visible")]
        public void VerifyTitleOfButtonsPage() =>
            Go.To<ButtonsPage>().
                ButtonsTitle.Should.Be("Buttons");

        [Test, Description("Verify text 'You have done a dynamic click' is not visible after page refresh")]
        public void VerifyMessageOfClickButtonIsNotVisibleAfrePageRefresh() =>
            Go.To<ButtonsPage>().
                ClickMe.Click().
                DinamicClickMessage.Should.Be("You have done a dynamic click").
                RefreshPage().
                DinamicClickMessage.Should.Not.BeVisible();
    }
}
