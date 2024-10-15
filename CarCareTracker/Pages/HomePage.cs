using Microsoft.Playwright;
using System;

namespace CarCareTracker.Pages
{
    internal class HomePage
    {
        private readonly IPage _page;


        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task Open()
        {
            await _page.GotoAsync(Constants.BaseUrl);
        }
        
        public async Task AddNewCar(int year, string make, string model, string licensePlate, string fuelType, bool useHours, bool odometerOptional, bool hasOdometerAdjustment, string tags)
        {
            await _page.Locator(".garage-item-add .card").ClickAsync();
            await _page.Locator("#inputYear").FillAsync(year.ToString());
            await _page.Locator("#inputMake").FillAsync(make);
            await _page.Locator("#inputModel").FillAsync(model);
            await _page.Locator("#inputLicensePlate").FillAsync(licensePlate);
            await _page.Locator("#inputFuelType").SelectOptionAsync(fuelType);
            await _page.Locator("#inputUseHours").SetCheckedAsync(useHours);
            await _page.Locator("#inputOdometerOptional").SetCheckedAsync(odometerOptional);
            await _page.Locator("#inputHasOdometerAdjustment").SetCheckedAsync(hasOdometerAdjustment);

            await _page.Locator("//*[@list='tagList']").FillAsync(tags);
            
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New Vehicle" }).ClickAsync();
        }
                
        public async Task OpenCar(string licensePlate)
        {
            await _page.Locator("p.card-text").GetByText(licensePlate, new() { Exact = true }).First.ClickAsync();
        }
        
        public ILocator GetUserNameLocator(string userName)
        {
            return _page.Locator(".dropdown").GetByRole(AriaRole.Button, new() { Name = userName });
        }

    }
}
