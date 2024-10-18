using NUnit.Framework;
using SpecFlowSeleniumDemoQA.Pages;

namespace SpecFlowSeleniumDemoQA.StepDefinitions
{
    [Binding]
    public class TextBoxStepDefinitions2 : BaseClass
    {
        public TextBoxStepDefinitions2(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Then(@"Output Name should be '([^']*)'")]
        public void ThenOutputNameShouldBe(string p0)
        {
            var textBoxPage = new TextBoxPage(_driver);
            Assert.That(textBoxPage.GetOutputName(), Is.EqualTo("Name:John Doe"));
        }
    }
}
