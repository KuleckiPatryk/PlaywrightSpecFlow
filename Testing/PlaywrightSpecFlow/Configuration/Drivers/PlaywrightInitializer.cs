using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightSpecFlow.Configuration.Screenshots;
using PlaywrightSpecFlow.Configuration.Settings;
using PlaywrightSpecFlow.Configuration.Settings.Models;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Configuration.Drivers
{
    [Binding]
    public class PlaywrightInitializer
    {
        private readonly IObjectContainer _objectContainer;

        private readonly PlaywrightSettings _playwrightSettings;

        private readonly BrowserService _browserService;

        private readonly BrowserContextService _browserContextService;

        private IPlaywright _playwright;

        private IBrowserContext _browserContext;

        private IPage _page;

        private IBrowser _browser;

        public PlaywrightInitializer(
            ISettings settings,
            IObjectContainer objectContainer,
            BrowserService browserService,
            BrowserContextService browserContextService)
        {
            _objectContainer = objectContainer;
            _browserService = browserService;
            _browserContextService = browserContextService;
            _playwrightSettings = settings.PlaywrightSettings;
        }

        [Before(Order = (int)InitializationOrder.Playwright)]
        public async Task Initialize()
        {
            _playwright = await Playwright.CreateAsync().ConfigureAwait(false);

            _browser = await _browserService.GetBrowserAsync(_playwright, _playwrightSettings.BrowserName).ConfigureAwait(false);

            _browserContext = await _browserContextService.GetBrowserContextAsync(_browser).ConfigureAwait(false);

            _page = await _browserContext.NewPageAsync().ConfigureAwait(false);

            _objectContainer.RegisterInstanceAs(_page);
        }

        [After]
        public async Task Dispose(ScreenshotService screenshotService)
        {
            await screenshotService.TakeScreenshot(TestContext.CurrentContext).ConfigureAwait(false);
            await _browserContext.CloseAsync().ConfigureAwait(false);
            await _browser.CloseAsync().ConfigureAwait(false);

            _playwright.Dispose();
        }
    }
}
