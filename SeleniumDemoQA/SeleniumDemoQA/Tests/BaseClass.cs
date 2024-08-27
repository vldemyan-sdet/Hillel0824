using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoQA.Tests
{
    public class BaseClass
    {
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _js = (IJavaScriptExecutor)_driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void FillInput(By selector, string value)
        {
            var inputElement = GetElementBy(selector);
            ScrollTo(inputElement);
            inputElement.SendKeys(value);
        }

        public void ClickElement(By selector)
        {
            var element = GetElementBy(selector);
            ScrollTo(element);
            element.Click();
        }

        public void SelectByText(By selector, string text)
        {
            var selectElement = new SelectElement(GetElementBy(selector));
            selectElement.SelectByText(text);
        }

        public string GetBorderColor(By selector)
        {
            var element = GetElementBy(selector);
            ScrollTo(element);
            return element.GetCssValue("border-color");
        }

        public IWebElement GetElementBy(By selector)
        {
            return _driver.FindElement(selector);
        }
    }
}
