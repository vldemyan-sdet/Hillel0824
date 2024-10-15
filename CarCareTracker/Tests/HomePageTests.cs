using CarCareTracker.Pages;
using Microsoft.Playwright;

namespace CarCareTracker.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class HomePageTests : UITestFixture
    {
        [Test]
        public async Task CheckoutAsNewUser()
        {
            // Arrange
            var homePage = new HomePage(page);
            var serviceRecordPage = new ServiceRecordPage(page);
            var vehiclePage = new VehiclePage(page);


            // Act
            await homePage.Open();
            await homePage.AddNewCar(2008, "Audi", "A4", "BM 1234 MB", "Diesel", true, false, true, "tag 2");
            await homePage.OpenCar("BM 1234 MB");

            await vehiclePage.OpenServiceRecords();

            await serviceRecordPage.Add("10/13/2024", 123, "service record description", 105.89m, "tag1s");
            
            await page.PauseAsync();
            await homePage.Open();


            // Assert
        }        
        

    }
}
