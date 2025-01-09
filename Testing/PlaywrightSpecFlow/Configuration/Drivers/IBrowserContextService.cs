using Microsoft.Playwright;

namespace PlaywrightSpecFlow.Configuration.Drivers
{
    public interface IBrowserContextService
    {
        Task<IBrowserContext> GetBrowserContextAsync(IBrowser browser);
    }
}
