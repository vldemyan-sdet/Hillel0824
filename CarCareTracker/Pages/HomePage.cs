using Microsoft.Playwright;

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
            await _page.GotoAsync("https://localhost:54356");
        }

    }
}
