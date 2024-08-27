using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoQA.Pages
{
    internal class FormPage
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        public FormPage(IWebDriver driver) 
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }
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
