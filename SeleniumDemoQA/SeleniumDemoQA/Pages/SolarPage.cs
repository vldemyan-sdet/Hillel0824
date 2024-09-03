﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoQA.Models;

namespace SeleniumDemoQA.Pages
{
    internal class SolarPage : BasePage
    {
        private By loader = By.Id("p_prldr");
        private By solarPanelsLink = By.CssSelector(".list-inline [href='/shop/solar-panels']");
        private By filterButton = By.CssSelector(".filter-button");
        private By productTitle = By.CssSelector(".card-content .list-product-title");

        public SolarPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo("https://solartechnology.com.ua/shop");

            WaitForLoader();
        }
        
        public void WaitForLoader()
        {
            WaitForElementVisible(loader);
            WaitForElementInvisible(loader);
        }

        public void OpenSolarPanels()
        {
            WaitAndClickElement(solarPanelsLink);

            WaitForLoader();
        }
        
        public void OpenFilters()
        {
            WaitAndClickElement(filterButton);
        }
                
        public void CheckBrand(string brand)
        {
            var brandCheckbox = By.XPath($"//*[@id='checkbox-brand']/following-sibling::span[text()='{brand}']");
            WaitAndClickElement(brandCheckbox);

            WaitForLoader();
        }
                        
        public string GetFirstProductTitleText()
        {
            return FindElement(productTitle).Text;
        }

    }
}