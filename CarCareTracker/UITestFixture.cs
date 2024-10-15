using Microsoft.Playwright;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace CarCareTracker
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
                Headless = false//ciEnv == "true"
            });

            string subPath = "../../../playwright/.auth";
            string filePath = "../../../playwright/.auth/state.json";

            if (!Directory.Exists(subPath))
                Directory.CreateDirectory(subPath);

            
            if (!File.Exists(filePath))
                File.AppendAllText(filePath, "{}");


            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                IgnoreHTTPSErrors = true,

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

            //var multipart = context.APIRequest.CreateFormData();
            //// Only name and value are set.
            //multipart.Append("userName", "test");
            //multipart.Append("password", "1234");


            //await page.APIRequest.PostAsync("https://localhost:54356/Login/Login", 
            //    new() { Form = multipart });
            await page.GotoAsync("https://localhost:54356/Home");
            if (await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).IsVisibleAsync())
            {
                await page.Locator("#inputUserName").FillAsync("test");
                await page.Locator("#inputUserPassword").FillAsync("1234");
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

                await context.StorageStateAsync(new()
                {
                    Path = "../../../playwright/.auth/state.json"
                });
            }

            page.SetDefaultTimeout(5000);
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
