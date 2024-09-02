using OpenQA.Selenium;
using SeleniumDemoQA.Models;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class FormTests : BaseClass
    {

        [Test]
        public void FillAndSubmitFormTest()
        {
            var formPage = new FormPage(_driver);

            formPage.NavigateTo("https://demoqa.com/automation-practice-form");
            formPage.FillFirstName("John");
            formPage.FillLastName("Doe");
            formPage.FillEmail("johndoe@example.com");
            formPage.SelectGender(Gender.Male);
            formPage.FillMobileNumber("1234567890");
            formPage.SelectDateOfBirth("May", "1990", "15");
            formPage.FillSubject("Maths");
            formPage.SelectHobby("Sport");
            formPage.FillCurrentAddress("123 Main Street, Anytown, USA");
            formPage.SelectState("NCR");
            formPage.SelectCity("Delhi");
            formPage.SubmitForm();

            Assert.IsTrue(formPage.IsConfirmationModalDisplayed());
            Assert.That(formPage.GetConfirmationModalText(), Is.EqualTo("Thanks for submitting the form"));
        }

        [Test]
        public void VerifyFormValidationTest()
        {
            string redBorderColor = "rgb(220, 53, 69)";
            By firstNameInputBy = By.Id("firstName");
            By lastNameInputBy = By.Id("lastName");
            By emailInputBy = By.Id("userEmail");
            By mobileNumberInputBy = By.Id("userNumber");

            var formPage = new FormPage(_driver);
            formPage.NavigateTo("https://demoqa.com/automation-practice-form");
            formPage.SubmitForm();
            Thread.Sleep(1000);

            Assert.That(formPage.GetElementBorderColor(firstNameInputBy), Is.EqualTo(redBorderColor), "First Name validation failed.");
            Assert.That(formPage.GetElementBorderColor(lastNameInputBy), Is.EqualTo(redBorderColor), "Last Name validation failed.");
            // Assert.That(formPage.GetElementBorderColor(emailInputBy), Is.EqualTo(redBorderColor), "Email validation failed.");
            Assert.That(formPage.GetElementBorderColor(mobileNumberInputBy), Is.EqualTo(redBorderColor), "Mobile Number validation failed.");
        }

    }
}