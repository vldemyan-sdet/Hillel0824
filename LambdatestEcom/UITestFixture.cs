using Microsoft.Playwright;

namespace LambdatestEcom
{
    public class UITestFixture
    {
        public IPage page { get; private set; }
        private IBrowser browser;
        private IBrowserContext context;

        [SetUp]
        public async Task Setup()
        {
            var ciEnv = Environment.GetEnvironmentVariable("CI");

            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = ciEnv == "true"
            });

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                StorageStatePath = "../../../playwright/.auth/state.json"
            });

            await context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            page = await context.NewPageAsync();

            //await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
            //await page.GetByPlaceholder("E-Mail Address").ClickAsync();
            //await page.GetByPlaceholder("E-Mail Address").FillAsync("test111@test111.com");
            //await page.GetByPlaceholder("Password").ClickAsync();
            //await page.GetByPlaceholder("Password").FillAsync("qweasd123");
            //await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            //await context.StorageStateAsync(new()
            //{
            //    Path = "../../../playwright/.auth/state.json"
            //});

            //page.SetDefaultTimeout(5000);
        }

        [TearDown]
        public async Task Teardown()
        {
            await context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
            });

            await page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
