using Microsoft.Playwright;

namespace LambdatestEcom
{
    public class UITestFixture
    {
        public IPage page { get; private set; }
        private IBrowser browser;

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                }
            });

            page = await context.NewPageAsync();
            page.SetDefaultTimeout(5000);
        }

        [TearDown]
        public async Task Teardown()
        {
            await page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
