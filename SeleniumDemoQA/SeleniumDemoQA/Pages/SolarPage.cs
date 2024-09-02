using OpenQA.Selenium;
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
        }

        public void OpenSolarPanels()
        {
            //Thread.Sleep(3000);
            //var timeStart = DateTime.Now;
            //WaitForElementVisible(solarPanelsLink);
            //var timeEnd = DateTime.Now;
            //Console.WriteLine(timeEnd - timeStart);
            ClickElement(solarPanelsLink);
        }
        
        public void OpenFilters()
        {
            //Thread.Sleep(3000);
            //WaitForElementVisible(filterButton);
            ClickElement(filterButton);
        }
                
        public void CheckBrand(string brand)
        {
            //Thread.Sleep(3000);
            ClickElement(By.XPath($"//*[@id='checkbox-brand']/following-sibling::span[text()='{brand}']"));
        }
                        
        public string GetFirstProductTitleText()
        {
            return FindElement(productTitle).Text;
        }

    }
}