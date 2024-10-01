using Microsoft.Playwright;
using System;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class WebTablesTest
{
    IBrowserContext context;

    [SetUp]
    public async Task Setup()
    {

        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        context = await browser.NewContextAsync();

        await context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });


    }

    [TearDown]
    public async Task TearDown()
    {
        await context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }

    [Test]
    public async Task DeleteRow()
    {
        var ciEnv = Environment.GetEnvironmentVariable("CI");

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = ciEnv == "true",
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            .GetByTitle("Delete").ClickAsync();
        await Assertions.Expect(page.GetByText("Alden")).Not.ToBeVisibleAsync();
    }

    [Test]
    public async Task EditRow()
    {
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".rt-tr-group").Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) }).GetByTitle("Edit").ClickAsync();
        await page.GetByPlaceholder("Last Name").FillAsync("Doe");
        var salary = int.Parse(await page.GetByPlaceholder("Salary").InputValueAsync());
        await page.GetByPlaceholder("Salary").FillAsync($"{salary + salary * 0.1}");
        await page.GetByText("Submit").ClickAsync();
        await Assertions.Expect(page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            .GetByRole(AriaRole.Gridcell, new() { Name = "Doe", Exact = true }))
            .ToBeVisibleAsync();
    }

    [Test]
    public async Task AddRow()
    {
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://demoqa.com/webtables");
        var buttonAdd = page.GetByText("Add").And(page.GetByRole(AriaRole.Button));
        await buttonAdd.ClickAsync();

        await page.GetByPlaceholder("First Name").FillAsync("John");
        await page.GetByPlaceholder("Last Name").FillAsync("Doe");
        await page.GetByPlaceholder("name@example.com").FillAsync("john@doe.doe");
        await page.GetByPlaceholder("Age").FillAsync("40");
        await page.GetByPlaceholder("Salary").FillAsync("4000");
        await page.GetByPlaceholder("Department").FillAsync("QA");
        await page.GetByText("Submit").ClickAsync();

        var addedRow = await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "John", Exact = true }) }).AllAsync();


        var columnHeaders = await page.Locator(".rt-thead").GetByRole(AriaRole.Columnheader).AllTextContentsAsync();


        var addedRowCells = page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "John", Exact = true }) })
            .GetByRole(AriaRole.Gridcell);

        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("First Name", columnHeaders))).ToHaveTextAsync("John");
        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("Last Name", columnHeaders))).ToHaveTextAsync("Doe");
        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("Age", columnHeaders))).ToHaveTextAsync("40");
        await Assertions.Expect(addedRowCells.Nth(GetColumnIndex("Email", columnHeaders))).ToHaveTextAsync("john@doe.doe");



    }
    
    [Test]
    public async Task Solar()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://solartechnology.com.ua/shop");
        await page.GetByRole(AriaRole.Link, new() { Name = "Акумулятори" }).ClickAsync();
        await page.GetByText("Фільтр товарів").ClickAsync();
        await page.GetByText("BYD", new() { Exact = true }).ClickAsync();
        await page.GetByRole(AriaRole.Link, new() { Name = "BYD B-Box 10", Exact = true }).ClickAsync();

    }

    private int GetColumnIndex(string columnHeader, IReadOnlyList<string> columnHeaders)
    {
        return columnHeaders.ToList().IndexOf(columnHeader);
    }
}
