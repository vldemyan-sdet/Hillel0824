using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace SeleniumTests.RevizelyAdmin
{
    [TestFixture]
    public class SampleTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Run in headless mode
            chromeOptions.AddArgument("--no-sandbox");
            //_driver = new ChromeDriver("/app/chrome-linux64", chromeOptions);
            _driver = new ChromeDriver(chromeOptions);
        }

        [Test]
        public void SearchTest()
        {
            _driver.Navigate().GoToUrl("https://ecommerce-playground.lambdatest.io");
            var searchBox = _driver.FindElement(By.Name("search"));
            searchBox.SendKeys("hp");
            searchBox.Submit();

            var productsSelector = By.CssSelector(".product-thumb");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElements(productsSelector));

            Assert.That(_driver.FindElements(By.LinkText("HP LP3065")).Count, Is.GreaterThan(0));
        }
        
        [Test]
        public void SearchTestFail()
        {
            _driver.Navigate().GoToUrl("https://ecommerce-playground.lambdatest.io");
            var searchBox = _driver.FindElement(By.Name("search"));
            searchBox.SendKeys("hp");
            searchBox.Submit();

            var productsSelector = By.CssSelector(".product-thumb");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElements(productsSelector));

            Assert.That(_driver.FindElements(By.LinkText("NOT EXISTING PRODUCT")).Count, Is.GreaterThan(0));
        }

        [TearDown]
        public void TearDown()
        {
            TakeScreenshot(_driver);
            _driver.Quit();
        }

        public void TakeScreenshot(IWebDriver driver)
        {
            var screenshotsFolder = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshots");
            if (!Directory.Exists(screenshotsFolder))
            {
                Directory.CreateDirectory(screenshotsFolder);
            }

            SaveScreenshot(driver, GetImageName(screenshotsFolder));
        }

        private string? SaveScreenshot(IWebDriver driver, string fileName)
        {
            if (driver is not ITakesScreenshot) return null;
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(fileName);

            return fileName;
        }

        private string GetImageName(string screenshotsFolder)
        {
            for (var index = 1; index < 1000; index++)
            {
                var fileName = string.Format(@"{0}_{1}.png", SanitizeFileName(TestContext.CurrentContext.Test.Name), index);
                var filePath = Path.Combine(screenshotsFolder, fileName);

                if (!File.Exists(filePath))
                {
                    return filePath;
                }
            }

            throw new Exception("Index limit in MakeFileName");
        }

        private static string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));

            // Get invalid file name characters for the current platform
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // Build a regex pattern for invalid characters
            string pattern = $"[{Regex.Escape(new string(invalidChars))}]";

            // Replace invalid characters
            return Regex.Replace(fileName, pattern, string.Empty);
        }
    }
}
