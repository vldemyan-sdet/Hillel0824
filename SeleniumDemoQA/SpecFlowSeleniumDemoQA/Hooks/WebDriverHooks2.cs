using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SpecFlowSeleniumDemoQA.Hooks
{
    [Binding]
    public class WebDriverHooks2
    {
        private readonly ScenarioContext _scenarioContext;
        public WebDriverHooks2(ScenarioContext scenarioContext)
        {
            Console.WriteLine("WebDriverHooks2");
        }

        [BeforeScenario("myTag")]
        public void InitializeWebDriver2()
        {
            Console.WriteLine("------------------------- myTag");
        }

        [AfterScenario]
        public void CloseWebDriver2()
        {
            Console.WriteLine("CloseWebDriver2");
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext sc)
        {
            Console.WriteLine("BeforeStep " + sc.StepContext.StepInfo.Text);
        }

        [AfterStep]
        public void AfterStep()
        {
            Console.WriteLine("AfterStep");
        }
    }
}
