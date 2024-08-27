using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class TextBoxTests : BaseClass
    {
        [Test]
        public void FillAndSubmitTheTextBox()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            var formPage = new FormPage(_driver);

            var name = "Sasha B";
            var email = "Sasha@gmail.com";
            var currentAddress = "MyStreet, 100, MyCity, MyCountry, 123456";
            var permanentAddress = "Vesnyana Street, 10, Kyiv, Ukraine, 29004";

            formPage.FillInput(By.Id("userName"), name);
            formPage.FillInput(By.Id("userEmail"), email);
            formPage.FillInput(By.Id("currentAddress"), currentAddress);
            formPage.FillInput(By.Id("permanentAddress"), permanentAddress);

            // Scroll to Submit button and click it
            formPage.ClickElement(By.Id("submit"));

            // Assert that the submitted values are displayed correctly in the output form
            var nameResult = formPage.GetElementBy(By.Id("name"));
            var emailResult = formPage.GetElementBy(By.Id("email"));
            var currentAddressResult = formPage.GetElementBy(By.CssSelector("#output #currentAddress.mb-1"));
            var permanentAddressResult = formPage.GetElementBy(By.CssSelector("#output #permanentAddress.mb-1"));

            //The formatting of the output below is not quite right, in particular with the spaces, but leaving as is to pass the test
            Assert.That(nameResult.Text, Is.EqualTo("Name:" + name));
            Assert.That(emailResult.Text, Is.EqualTo("Email:" + email));
            Assert.That(currentAddressResult.Text, Is.EqualTo("Current Address :" + currentAddress));
            Assert.That(permanentAddressResult.Text, Is.EqualTo("Permananet Address :" + permanentAddress));
        }

    }
}
