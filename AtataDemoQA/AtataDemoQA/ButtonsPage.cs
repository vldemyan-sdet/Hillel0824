namespace AtataDemoQA
{
    [Url("/buttons")]
    public sealed class ButtonsPage : Page<ButtonsPage>
    {
        [FindById("doubleClickBtn")]
        public Button<ButtonsPage> DoubleClickMe { get; private set; }

        [FindById("rightClickBtn")]
        public Button<ButtonsPage> RigthClickMe { get; private set; }

        [ScrollTo]
        public Button<ButtonsPage> ClickMe { get; private set; }

        [FindById("dynamicClickMessage")]
        public Text<ButtonsPage> DinamicClickMessage { get; private set; }

        [FindById("rightClickMessage")]
        public Text<ButtonsPage> RightClickMessage { get; private set; }

        [FindById("doubleClickMessage")]
        public Text<ButtonsPage> DoubleClickMessage { get; private set; }

        [FindByXPath("//h1[@class='text-center' and text()='Buttons']")]
        public H1<ButtonsPage> ButtonsTitle { get; set; }
    }
}
