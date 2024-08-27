using OpenQA.Selenium;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests : BaseClass
    {
        [Test]
        public void FillAndSubmitFormTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            FillInput(By.Id("firstName"), "John");
            FillInput(By.Id("lastName"), "Doe");

            FillInput(By.Id("userEmail"), "johndoe@example.com");
            ClickElement(By.CssSelector("label[for='gender-radio-1']"));

            FillInput(By.Id("userNumber"), "1234567890");

            ClickElement(By.Id("dateOfBirthInput"));
            SelectByText(By.ClassName("react-datepicker__month-select"), "May");
            SelectByText(By.ClassName("react-datepicker__year-select"), "1990");
            ClickElement(By.CssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)"));

            FillInput(By.Id("subjectsInput"), "Maths");
            GetElementBy(By.Id("subjectsInput")).SendKeys(Keys.Enter);

            ClickElement(By.CssSelector("label[for='hobbies-checkbox-1']"));

            FillInput(By.Id("currentAddress"), "123 Main Street, Anytown, USA");

            ClickElement(By.Id("state"));

            ClickElement(By.XPath("//div[text()='NCR']"));

            ClickElement(By.Id("city"));
            ClickElement(By.XPath("//div[text()='Delhi']"));

            ClickElement(By.Id("submit"));

            var confirmationModal = GetElementBy(By.Id("example-modal-sizes-title-lg"));

            Assert.IsTrue(confirmationModal.Displayed);
            Assert.That(confirmationModal.Text, Is.EqualTo("Thanks for submitting the form"));
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            ClickElement(By.Id("submit"));
            Thread.Sleep(2000);

            string firstNameBorderColor = GetBorderColor(By.Id("firstName"));

            string lastNameBorderColor = GetBorderColor(By.Id("lastName"));

            string mobileNumberBorderColor = GetBorderColor(By.Id("userNumber"));

            string expectedBorderColor = "rgb(220, 53, 69)";

            Assert.That(firstNameBorderColor, Is.EqualTo(expectedBorderColor), "First Name validation failed.");
            Assert.That(lastNameBorderColor, Is.EqualTo(expectedBorderColor), "Last Name validation failed.");
            Assert.That(mobileNumberBorderColor, Is.EqualTo(expectedBorderColor), "Mobile Number validation failed.");
        }
    }
}