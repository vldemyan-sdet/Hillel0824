using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoQA.Models;

namespace SeleniumDemoQA.Pages
{
    internal class FormPage : BasePage
    {
        private By firstNameInputBy = By.Id("firstName");
        private By lastNameInputBy = By.Id("lastName");
        private By emailInputBy = By.Id("userEmail");
        private By mobileNumberInputBy = By.Id("userNumber");
        private By currentAddressInputBy = By.Id("currentAddress");
        private By dateOfBirthInputBy = By.Id("dateOfBirthInput");
        private By monthPickerBy = By.ClassName("react-datepicker__month-select");
        private By yearPickerBy = By.ClassName("react-datepicker__year-select");
        private By subjectsInputBy = By.Id("subjectsInput");
        private By stateDropdownBy = By.Id("state");
        private By cityDropdownBy = By.Id("city");
        private By submitButtonBy = By.Id("submit");
        private By confirmationModalBy = By.Id("example-modal-sizes-title-lg");


        public FormPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillFirstName(string firstName)
        {
            FillInput(firstNameInputBy, firstName);
        }

        public void FillLastName(string lastName)
        {
            FillInput(lastNameInputBy, lastName);
        }

        public void FillEmail(string email)
        {
            FillInput(emailInputBy, email);
        }

        public void FillMobileNumber(string mobileNumber)
        {
            FillInput(mobileNumberInputBy, mobileNumber);
        }

        public void FillSubject(string subject)
        {
            FillInput(subjectsInputBy, subject);
            FindElement(subjectsInputBy).SendKeys(Keys.Enter);
        }

        public void FillCurrentAddress(string currentAddress)
        {
            FillInput(currentAddressInputBy, currentAddress);
        }

        public void SelectGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
                    break;
                case Gender.Female:
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-2']")).Click();
                    break;
                case Gender.Other:
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-3']")).Click();
                    break;
                default:
                    throw new Exception($"The gender option '{gender}' is not recognized.");
            }
        }

        public void SelectHobby(string hobby)
        {
            switch (hobby)
            {
                case "Sports":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
                    break;
                case "Reading":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']")).Click();
                    break;
                case "Music":
                    _driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-2']")).Click();
                    break;
                default:
                    Console.WriteLine($"The hobby option '{hobby}' is not recognized.");
                    break;
            }
        }

        public void SelectDateOfBirth(string month, string year, string day)
        {
            By dayPickerBy = By.CssSelector($".react-datepicker__day--0{day}:not(.react-datepicker__day--outside-month)");
            ClickElement(dateOfBirthInputBy);
            SelectDefinedElement(monthPickerBy, month);
            SelectDefinedElement(yearPickerBy, year);
            ClickElement(dayPickerBy);
        }

        public void SelectState(string state)
        {
            ClickElement(stateDropdownBy);
            ClickElement(By.XPath($"//div[text()='{state}']"));
        }

        public void SelectCity(string city)
        {
            ClickElement(cityDropdownBy);
            ClickElement(By.XPath($"//div[text()='{city}']"));
        }

        public void SubmitForm()
        {
            ClickElement(submitButtonBy);
        }

        public string GetElementBorderColor(By element)
        {
            ScrollTo(FindElement(element));
            return FindElement(element).GetCssValue("border-color");
        }

        public string GetConfirmationModalText()
        {
            return FindElement(confirmationModalBy).Text;
        }

        public bool IsConfirmationModalDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.FindElement(confirmationModalBy).Displayed);
        }
    }
}