using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests
    {
        private IWebDriver _driver;
        IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            _js = (IJavaScriptExecutor)_driver;
        }

        private void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
          
        private void FillInput(By selector, string value)
        {
            var firstNameInput = _driver.FindElement(selector);
            ScrollTo(firstNameInput);
            firstNameInput.SendKeys(value);
        }
                
        private void ClickElement(By selector)
        {
            var genderRadioButton = _driver.FindElement(selector);
            ScrollTo(genderRadioButton);
            genderRadioButton.Click();
        }

        [Test]
        public void FillAndSubmitFormTest()
        {
            FillInput(By.Id("firstName"), "John");
            FillInput(By.Id("lastName"), "Doe");

            // Scroll to Email and fill it out
            var emailInput = _driver.FindElement(By.Id("userEmail"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", emailInput);
            emailInput.SendKeys("johndoe@example.com");

            ClickElement(By.CssSelector("label[for='gender-radio-1']"));

            // Scroll to Mobile Number and fill it out
            var mobileNumberInput = _driver.FindElement(By.Id("userNumber"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", mobileNumberInput);
            mobileNumberInput.SendKeys("1234567890");

            // Scroll to Date of Birth and set it
            var dateOfBirthInput = _driver.FindElement(By.Id("dateOfBirthInput"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", dateOfBirthInput);
            dateOfBirthInput.Click();

            var selectMonth = new SelectElement(_driver.FindElement(By.ClassName("react-datepicker__month-select")));
            selectMonth.SelectByText("May");

            var selectYear = new SelectElement(_driver.FindElement(By.ClassName("react-datepicker__year-select")));
            selectYear.SelectByText("1990");

            var selectDay = _driver.FindElement(By.CssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)"));
            selectDay.Click();

            // Scroll to Subjects and fill it out
            var subjectsInput = _driver.FindElement(By.Id("subjectsInput"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", subjectsInput);
            subjectsInput.SendKeys("Maths");
            subjectsInput.SendKeys(Keys.Enter);

            // Scroll to Hobbies and select one
            var hobbiesCheckbox = _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", hobbiesCheckbox);
            hobbiesCheckbox.Click();

            // Scroll to Current Address and fill it out
            var currentAddressInput = _driver.FindElement(By.Id("currentAddress"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", currentAddressInput);
            currentAddressInput.SendKeys("123 Main Street, Anytown, USA");

            // Scroll to State dropdown and select a state
            var stateDropdown = _driver.FindElement(By.Id("state"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", stateDropdown);
            stateDropdown.Click();
            var selectState = _driver.FindElement(By.XPath("//div[text()='NCR']"));
            selectState.Click();

            // Scroll to City dropdown and select a city
            var cityDropdown = _driver.FindElement(By.Id("city"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", cityDropdown);
            cityDropdown.Click();
            var selectCity = _driver.FindElement(By.XPath("//div[text()='Delhi']"));
            selectCity.Click();

            // Scroll to Submit button and click it
            var submitButton = _driver.FindElement(By.Id("submit"));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();

            // Validate the Form Submission (e.g., check for the confirmation modal)
            var confirmationModal = _driver.FindElement(By.Id("example-modal-sizes-title-lg"));
            Assert.IsTrue(confirmationModal.Displayed);
            Assert.AreEqual("Thanks for submitting the form", confirmationModal.Text);
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            var js = (IJavaScriptExecutor)_driver;

            // Scroll to and click the Submit button without filling any field
            var submitButton = _driver.FindElement(By.Id("submit"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();

            // Scroll to and verify validation for First Name
            var firstNameInput = _driver.FindElement(By.Id("firstName"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", firstNameInput);
            string firstNameBorderColor = firstNameInput.GetCssValue("border-color");

            // Scroll to and verify validation for Last Name
            var lastNameInput = _driver.FindElement(By.Id("lastName"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", lastNameInput);
            string lastNameBorderColor = lastNameInput.GetCssValue("border-color");

            // Scroll to and verify validation for Email
            var emailInput = _driver.FindElement(By.Id("userEmail"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", emailInput);
            string emailBorderColor = emailInput.GetCssValue("border-color");

            // Scroll to and verify validation for Mobile Number
            var mobileNumberInput = _driver.FindElement(By.Id("userNumber"));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", mobileNumberInput);
            string mobileNumberBorderColor = mobileNumberInput.GetCssValue("border-color");

            // Check if the border color indicates an error (commonly red)
            string expectedBorderColor = "rgb(210, 166, 175)"; // Adjust this if the page uses a different color

            Assert.AreEqual(expectedBorderColor, firstNameBorderColor, "First Name validation failed.");
            Assert.AreEqual(expectedBorderColor, lastNameBorderColor, "Last Name validation failed.");
            Assert.AreEqual(expectedBorderColor, emailBorderColor, "Email validation failed.");
            Assert.AreEqual(expectedBorderColor, mobileNumberBorderColor, "Mobile Number validation failed.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
