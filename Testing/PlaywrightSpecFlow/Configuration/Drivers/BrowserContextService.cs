using Microsoft.Playwright;
using PlaywrightSpecFlow.Configuration.Settings;

namespace PlaywrightSpecFlow.Configuration.Drivers
{
    public class BrowserContextService : IBrowserContextService
    {
        private readonly ISettings _settings;

        public BrowserContextService(ISettings settings)
        {
            _settings = settings;
        }

        public async Task<IBrowserContext> GetBrowserContextAsync(IBrowser browser)
        {
            var browserContext = await browser.NewContextAsync(GetOptions()).ConfigureAwait(false);

            return browserContext;
        }

        private BrowserNewContextOptions GetOptions() => new() { ViewportSize = ViewportSize.NoViewport, BaseURL = _settings.BaseUrl };
    }
}
