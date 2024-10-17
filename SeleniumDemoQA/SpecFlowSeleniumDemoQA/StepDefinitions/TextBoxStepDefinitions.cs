using NUnit.Framework;
using SpecFlowSeleniumDemoQA.Pages;

namespace SpecFlowSeleniumDemoQA.StepDefinitions
{
    [Binding]
    public class TextBoxStepDefinitions : BaseClass
    {
        public TextBoxStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"Open Text Box page")]
        public void GivenOpenTextBoxPage()
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.NavigateTo("https://demoqa.com/text-box");
        }

        [When(@"Fill Full Name '([^']*)'")]
        public void WhenFillFullName(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillFullName("John Doe");
        }

        [When(@"Fill Email '([^']*)'")]
        public void WhenFillEmail(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillEmail("john.doe@example.com");
        }

        [When(@"Fill Current Address '([^']*)'")]
        public void WhenFillCurrentAddress(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillCurrentAddress("123 Main St, Anytown, USA");
        }

        [When(@"Fill Permanent Address '([^']*)'")]
        public void WhenFillPermanentAddress(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.FillPermanentAddress("456 Another St, Othertown, USA");
        }

        [When(@"Submit Form")]
        public void WhenSubmitForm()
        {
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.SubmitForm();
        }

        [Then(@"Output Name should be '([^']*)'")]
        public void ThenOutputNameShouldBe(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            Assert.That(textBoxPage.GetOutputName(), Is.EqualTo("Name:John Doe"));
        }
    }
}
