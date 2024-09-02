using OpenQA.Selenium;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class TextBoxTests : BaseClass
    {
        [Test]
        public void FillFormTest()
        {
            // Arrange
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.NavigateTo("https://demoqa.com/text-box");

            // Act
            textBoxPage.FillFullName("John Doe");
            textBoxPage.FillEmail("john.doe@example.com");
            textBoxPage.FillCurrentAddress("123 Main St, Anytown, USA");
            textBoxPage.FillPermanentAddress("456 Another St, Othertown, USA");
            textBoxPage.SubmitForm();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(textBoxPage.GetOutputName(), Is.EqualTo("Name:John Doe"));
                Assert.That(textBoxPage.GetOutputEmail, Is.EqualTo("Email:john.doe@example.com"));
                Assert.That(textBoxPage.GetOutputCurrentAddress, Is.EqualTo("Current Address :123 Main St, Anytown, USA"));
                Assert.That(textBoxPage.GetOutputPermanentAddress, Is.EqualTo("Permananet Address :456 Another St, Othertown, USA"));
            });
        }
    }
}
