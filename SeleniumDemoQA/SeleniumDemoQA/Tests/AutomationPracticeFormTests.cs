using OpenQA.Selenium;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests : BaseClass
    {
        [Test]
        public void FillAndSubmitFormTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            var formPage = new FormPage(_driver);
            

            //formPage.FillInput(By.Id("firstName"), "John");
            formPage.FillFirstName("John");

            formPage.FillInput(By.Id("lastName"), "Doe");
            formPage.FillInput(By.Id("userEmail"), "johndoe@example.com");
            formPage.ClickElement(By.CssSelector("label[for='gender-radio-1']"));
            formPage.FillInput(By.Id("userNumber"), "1234567890");
            formPage.ClickElement(By.Id("dateOfBirthInput"));
            formPage.SelectByText(By.ClassName("react-datepicker__month-select"), "May");
            formPage.SelectByText(By.ClassName("react-datepicker__year-select"), "1990");
            formPage.ClickElement(By.CssSelector($".react-datepicker__day--015:not(.react-datepicker__day--outside-month)"));
            formPage.FillInput(By.Id("subjectsInput"), "Maths");
            formPage.GetElementBy(By.Id("subjectsInput")).SendKeys(Keys.Enter);
            formPage.ClickElement(By.CssSelector("label[for='hobbies-checkbox-1']"));
            formPage.FillInput(By.Id("currentAddress"), "123 Main Street, Anytown, USA");
            formPage.ClickElement(By.Id("state"));
            formPage.ClickElement(By.XPath("//div[text()='NCR']"));
            formPage.ClickElement(By.Id("city"));
            formPage.ClickElement(By.XPath("//div[text()='Delhi']"));
            formPage.ClickElement(By.Id("submit"));

            //var confirmationModal = formPage.GetElementBy(By.Id("example-modal-sizes-title-lg"));
            var isConfirmationModalDisplayed = formPage.IsConfirmationModalDisplayed();
            var confirmationModalText = formPage.GetConfirmationModalText();

            //Assert.IsTrue(confirmationModal.Displayed);
            Assert.IsTrue(isConfirmationModalDisplayed);
            //Assert.That(confirmationModal.Text, Is.EqualTo("Thanks for submitting the form"));
            Assert.That(confirmationModalText, Is.EqualTo("Thanks for submitting the form"));
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            var formPage = new FormPage(_driver);

            formPage.ClickElement(By.Id("submit"));
            Thread.Sleep(2000);

            string firstNameBorderColor = formPage.GetBorderColor(By.Id("firstName"));

            string lastNameBorderColor = formPage.GetBorderColor(By.Id("lastName"));

            string mobileNumberBorderColor = formPage.GetBorderColor(By.Id("userNumber"));

            string expectedBorderColor = "rgb(220, 53, 69)";

            Assert.That(firstNameBorderColor, Is.EqualTo(expectedBorderColor), "First Name validation failed.");
            Assert.That(lastNameBorderColor, Is.EqualTo(expectedBorderColor), "Last Name validation failed.");
            Assert.That(mobileNumberBorderColor, Is.EqualTo(expectedBorderColor), "Mobile Number validation failed.");
        }
    }
}