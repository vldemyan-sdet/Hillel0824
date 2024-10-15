using Microsoft.Playwright;

namespace CarCareTracker.Pages
{
    internal class VehiclePage
    {
        private readonly IPage _page;

        public VehiclePage(IPage page)
        {
            _page = page;
        }
     
        public async Task OpenServiceRecords()
        {
            await _page.GetByRole(AriaRole.Tablist).Locator("#servicerecord-tab").ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add Service Record" }).WaitForAsync();
        }

    }
}
