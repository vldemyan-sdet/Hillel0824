using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class ButtonTests : BaseClass
    {
        ButtonPage buttonPage;

        [SetUp]
        public void Setup()
        {
            //Arrange
            buttonPage = new ButtonPage(_driver);
            buttonPage.NavigateTo("https://demoqa.com/buttons");
        }

        [Test]
        public void DoubleClickButtonTest()
        {
            //Act
            buttonPage.DoubleClickTheDoubleClickButton();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(buttonPage.IsDoubleClickOutputMessageDisplayed(), Is.True);
                Assert.That(buttonPage.GetDoubleClickMessageText(), Is.EqualTo("You have done a double click"));
            });
        }

        [Test]
        public void RightClickButtonTest()
        {
            //Act
            buttonPage.RightClickTheRightClickButton();

            //Assert
            Assert.That(buttonPage.IsRightClickOutputMessageDisplayed(), Is.True);
            Assert.That(buttonPage.GetRightClickMessageText(), Is.EqualTo("You have done a right click"));
        }

        [Test]
        public void ClickMeButtonTest()
        {
            //Act
            buttonPage.ClickTheClickMeButton();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(buttonPage.IsDynamicClickOutputMessageDisplayed(), Is.True);
                Assert.That(buttonPage.GetDynamicClickMessageText(), Is.EqualTo("You have done a dynamic click"));
            });
        }
    }
}