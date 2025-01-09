using Microsoft.Playwright;

namespace PlaywrightSpecFlow.Configuration.Drivers
{
    public interface IBrowserService
    {
        Task<IBrowser> GetBrowserAsync(IPlaywright playwright, string browserName);
    }
}
