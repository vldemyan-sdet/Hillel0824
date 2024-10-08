using CarCareTracker.Pages;
using Microsoft.Playwright;

namespace CarCareTracker.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : UITestFixture
    {
        [Test]
        public async Task CheckoutAsNewUser()
        {
            // Arrange
            var homePage = new HomePage(page);


            // Act
            await homePage.Open();


            // Assert
        }        
        

    }
}
