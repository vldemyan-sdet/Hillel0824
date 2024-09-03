using OpenQA.Selenium;
using SeleniumDemoQA.Models;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class SolarTests : BaseClass
    {

        [Test]
        public void VerifyFiltering()
        {
            // Arrange
            var solarPage = new SolarPage(_driver);
            solarPage.Open();
            solarPage.OpenSolarPanels();
            solarPage.OpenFilters();

            // Act
            var firstProductTextBefore = solarPage.GetFirstProductTitleText();
            solarPage.CheckBrand("JA Solar");
            var firstProductTextAfter = solarPage.GetFirstProductTitleText();

            // Assert
            //MyAssert.NotEqual(firstProductTextAfter, firstProductTextBefore);
            Assert.That(firstProductTextAfter, Is.Not.EqualTo(firstProductTextBefore));
        }


    }
}