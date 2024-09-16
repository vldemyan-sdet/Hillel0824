using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace SeleniumDemoQA.Pages
{
    internal class ButtonPage : BasePage
    {
        Actions actions;
        By doubleClickButtonSelector = By.Id("doubleClickBtn");
        By doubleClickMessageSelector = By.Id("doubleClickMessage");

        By rightClickButtonSelector = By.Id("rightClickBtn");
        By rightClickMessageSelector = By.Id("rightClickMessage");

        By dynamicClickButtonSelector = By.XPath("//button[text()='Click Me']");
        By dynamicClickMessageSelector = By.Id("dynamicClickMessage");

        public ButtonPage(IWebDriver driver) : base(driver)
        {
            actions = new Actions(driver);
        }

        public void DoubleClickTheDoubleClickButton()
        {
            var doubleClickButton = GetElementBy(doubleClickButtonSelector);
            WaitForElementVisible(doubleClickButtonSelector);
            actions.DoubleClick(doubleClickButton).Perform();
        }

        public void RightClickTheRightClickButton()
        {
            var rightClickButton = GetElementBy(rightClickButtonSelector);
            WaitForElementVisible(rightClickButtonSelector);
            actions.ContextClick(rightClickButton).Perform();
        }
        public void ClickTheClickMeButton()
        {
            WaitAndClickElement(dynamicClickButtonSelector);
        }

        public string GetDoubleClickMessageText()
        {
            return GetElementText(doubleClickMessageSelector);
        }

        public string GetRightClickMessageText()
        {
            return GetElementText(rightClickMessageSelector);
        }

        public string GetDynamicClickMessageText()
        {
            return GetElementText(dynamicClickMessageSelector);
        }

        public bool IsDoubleClickOutputMessageDisplayed()
        {
            return IsElementDisplayed(doubleClickMessageSelector);
        }

        public bool IsRightClickOutputMessageDisplayed()
        {
            return IsElementDisplayed(rightClickMessageSelector);
        }

        public bool IsDynamicClickOutputMessageDisplayed()
        {
            return IsElementDisplayed(dynamicClickMessageSelector);
        }
    }
}
