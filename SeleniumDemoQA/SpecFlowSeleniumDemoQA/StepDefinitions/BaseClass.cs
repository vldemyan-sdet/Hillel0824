﻿using OpenQA.Selenium;
using SpecFlowSeleniumDemoQA.Pages;

namespace SpecFlowSeleniumDemoQA.StepDefinitions
{
    public abstract class BaseClass
    {
        public IWebDriver _driver;

        public TextBoxPage textBoxPage;
        public ScenarioContext scenarioContext;
        public BaseClass(ScenarioContext scenarioContext)
        {
            scenarioContext = scenarioContext;
            _driver = scenarioContext["WebDriver"] as IWebDriver;

            textBoxPage = new TextBoxPage(_driver);

        }
    }
}
