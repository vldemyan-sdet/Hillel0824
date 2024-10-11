using LambdatestEcom.Pages;
using Microsoft.Playwright;

namespace LambdatestEcom.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : UITestFixture
    {
        [Test]
        public async Task CheckoutAsNewUser()
        {
            // Arrange
            DateTime now = DateTime.Now;
            string randomString = now.ToString("yyyyMMddHHmmss");

            var homePage = new HomePage(page);
            var catalogPage = new CatalogPage(page);
            var checkoutPage = new CheckoutPage(page);

            // Act
            await homePage.Open();
            await homePage.OpenCategory("Laptops & Notebooks");

            await catalogPage.FilterAvailability("In stock");
            await catalogPage.AddProductToCart(5);
            await catalogPage.GoToCheckout();

            await checkoutPage.FillUserInfo(randomString);
            await checkoutPage.AcceptPolicies();
            await checkoutPage.ConfirmOrder();
            await checkoutPage.Continue();

            // Assert
            StringAssert.EndsWith("?route=common/home", page.Url);
        }        
        
        [Test]
        public async Task CheckoutAsExistingUser()
        {
            // Arrange
            DateTime now = DateTime.Now;
            string randomString = now.ToString("yyyyMMddHHmmss");

            var homePage = new HomePage(page);
            var catalogPage = new CatalogPage(page);
            var checkoutPage = new CheckoutPage(page);

            // Act
            await homePage.Open();
            await homePage.OpenCategory("Laptops & Notebooks");

            await catalogPage.FilterAvailability("In stock");
            await page.PauseAsync();
            await catalogPage.AddProductToCart(5);
            await catalogPage.GoToCheckout();

            await checkoutPage.FillUserInfo(randomString);
            await checkoutPage.AcceptPolicies();
            await checkoutPage.ConfirmOrder();
            await checkoutPage.Continue();

            // Assert
            StringAssert.EndsWith("?route=common/home", page.Url);
        }

    }
}
