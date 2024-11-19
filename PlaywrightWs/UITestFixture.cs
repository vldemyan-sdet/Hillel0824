using Microsoft.Playwright;

namespace PlayWrightWs
{
    public class UITestFixture
    {
        public IPage Page { get; private set; }
        private IBrowser browser;
        public IBrowserContext context;

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                }
            });

            Page = await context.NewPageAsync();
            Page.SetDefaultTimeout(5000);
        }

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
