﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemoQA.Tests
{
    public abstract class BaseClass
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _js = (IJavaScriptExecutor)_driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
