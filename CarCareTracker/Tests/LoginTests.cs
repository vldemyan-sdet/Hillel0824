using CarCareTracker.Pages;
using Microsoft.Playwright;

namespace CarCareTracker.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTest : UITestFixture
    {
        [Test]
        public async Task CheckStateIsLoaded()
        {
            // Arrange
            var homePage = new HomePage(page);

            // Act
            await homePage.Open();

            // Assert
            await Assertions.Expect(homePage.GetUserNameLocator("test")).ToBeVisibleAsync();
        }        
        

    }
}
