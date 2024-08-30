using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoQA.Pages
{
    internal class FormPage

    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

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


        public FormPage(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }

        public void NavigateTo(string link)
        {
            _driver.Navigate().GoToUrl(link);
        }

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void FillInput(By selector, string value)
        {
            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.SendKeys(value);
        }

        public void ClickElement(By selector)
        {
            IWebElement element = FindElement(selector);
            ScrollTo(element);
            element.Click();
        }

        public void SelectDefinedElement(By selector, string value)
        {
            var elements = new SelectElement(FindElement(selector));
            elements.SelectByText(value);
        }

        public IWebElement FindElement(By by)
        {
            IWebElement element = _driver.FindElement(by);
            return element;
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

        public void SelectGender(string gender)
        {
            switch (gender)
            {
                case "Male":
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
                    break;
                case "Female":
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-2']")).Click();
                    break;
                case "Other":
                    _driver.FindElement(By.CssSelector("label[for='gender-radio-3']")).Click();
                    break;
                default:
                    Console.WriteLine($"The gender option '{gender}' is not recognized.");
                    break;
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