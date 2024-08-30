using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDemoQA.Tests
{
    public class ButtonTests : BaseClass
    {
        [Test]
        public void DoubleClickButtonTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            var doubleClickButton = _driver.FindElement(By.Id("doubleClickBtn"));
            var actions = new Actions(_driver);
            actions.DoubleClick(doubleClickButton).Perform();

            var doubleClickMessage = _driver.FindElement(By.Id("doubleClickMessage"));
            Assert.IsTrue(doubleClickMessage.Displayed);
            Assert.That(doubleClickMessage.Text, Is.EqualTo("You have done a double click"));
        }

        [Test]
        public void RightClickButtonTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            var rightClickButton = _driver.FindElement(By.XPath("//button[text()='Right Click Me']"));
            Actions actions = new Actions(_driver);
            actions.ContextClick(rightClickButton).Perform();

            var rightClickMessage = _driver.FindElement(By.Id("rightClickMessage"));
            Assert.IsTrue(rightClickMessage.Displayed);
            Assert.That(rightClickMessage.Text, Is.EqualTo("You have done a right click"));
        }

        [Test]
        public void ClickMeButtonTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            var clickMeButton = _driver.FindElement(By.XPath("//button[text()='Click Me']"));
            clickMeButton.Click();

            var dynamicClickMessage = _driver.FindElement(By.Id("dynamicClickMessage"));
            Assert.IsTrue(dynamicClickMessage.Displayed);
            Assert.That(dynamicClickMessage.Text, Is.EqualTo("You have done a dynamic click"));
        }
    }
}