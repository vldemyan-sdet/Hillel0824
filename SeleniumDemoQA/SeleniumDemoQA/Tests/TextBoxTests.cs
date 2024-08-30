using OpenQA.Selenium;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class TextBoxTests : BaseClass
    {
        By fullNameBy = By.Id("userName");
        By emailBy = By.Id("userEmail");
        By currentAddressBy = By.Id("currentAddress");
        By permanentAddressBy = By.Id("permanentAddress");
        By nameOutputBy = By.Id("name");
        By emailOutputBy = By.Id("email");
        By currentOutputAddressBy = By.CssSelector("#output  #currentAddress");
        By permanentOutputAddressBy = By.CssSelector("#output  #permanentAddress");

        [Test]
        public void FillFormTest()
        {
            var formPage = new FormPage(_driver);
            formPage.NavigateTo("https://demoqa.com/text-box");

            formPage.FindElement(fullNameBy).SendKeys("John Doe");
            formPage.FindElement(emailBy).SendKeys("john.doe@example.com");
            formPage.FindElement(currentAddressBy).SendKeys("123 Main St, Anytown, USA");
            formPage.FindElement(permanentAddressBy).SendKeys("456 Another St, Othertown, USA");
            formPage.SubmitForm();

            Assert.That(formPage.FindElement(nameOutputBy).Text, Is.EqualTo("Name:John Doe"));
            Assert.That(formPage.FindElement(emailOutputBy).Text, Is.EqualTo("Email:john.doe@example.com"));
            Assert.That(formPage.FindElement(currentOutputAddressBy).Text, Is.EqualTo("Current Address :123 Main St, Anytown, USA"));
            Assert.That(formPage.FindElement(permanentOutputAddressBy).Text, Is.EqualTo("Permananet Address :456 Another St, Othertown, USA"));
        }
    }
}
