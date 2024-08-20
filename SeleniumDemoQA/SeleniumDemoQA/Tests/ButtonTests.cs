using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace SeleniumDemoQA.Tests
{
    public class ButtonTests
    {
        private ChromeDriver _driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();

            // Set the window size
            options.AddArgument("window-size=1400,1200"); // Set your desired resolution here

            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        }

        [Test]
        public void DoubleClickButtonTest()
        {
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
            var clickMeButton = _driver.FindElement(By.XPath("//button[text()='Click Me']"));
            clickMeButton.Click();

            var dynamicClickMessage = _driver.FindElement(By.Id("dynamicClickMessage"));
            Assert.IsTrue(dynamicClickMessage.Displayed);
            Assert.That(dynamicClickMessage.Text, Is.EqualTo("You have done a dynamic click"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
