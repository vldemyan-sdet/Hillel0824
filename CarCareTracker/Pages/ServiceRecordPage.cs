using Microsoft.Playwright;

namespace CarCareTracker.Pages
{
    internal class ServiceRecordPage
    {
        private readonly IPage _page;

        public ServiceRecordPage(IPage page)
        {
            _page = page;
        }
     
        public async Task Add(string date, int milage, string description, decimal cost, string tag, string serviceRecordNotes = "")
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add Service Record" }).ClickAsync();
            await _page.Locator("#serviceRecordDate").ClearAsync();
            await _page.Locator("#serviceRecordDate").PressSequentiallyAsync(date);
            await _page.Locator(".active.day").ClickAsync();
            await _page.Locator("#serviceRecordMileage").FillAsync(milage.ToString());
            await _page.Locator("#serviceRecordDescription").FillAsync(description);
            await _page.Locator("#serviceRecordCost").FillAsync(cost.ToString());
            await _page.Locator("//*[@list='tagList']").FillAsync(tag);
            await _page.Locator("#serviceRecordNotes").FillAsync(serviceRecordNotes);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New Service Record" }).ClickAsync();
        }

    }
}
