using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoQA.Pages
{
    internal class BasePage
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }

        public void NavigateTo(string link)
        {
            _driver.Navigate().GoToUrl(link);
        }

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void FillInput(By selector, string value)
        {
            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.SendKeys(value);
        }

        public void ClickElement(By selector)
        {
            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.Click();
        }

        public void SelectDefinedElement(By selector, string value)
        {
            var elements = new SelectElement(FindElement(selector));
            elements.SelectByText(value);
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element = _driver.FindElement(by);
            return element;
        }

    }
}
