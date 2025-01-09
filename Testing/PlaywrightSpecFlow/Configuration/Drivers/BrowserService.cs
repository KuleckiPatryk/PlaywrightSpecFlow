using Microsoft.Playwright;
using PlaywrightSpecFlow.Configuration.Settings;
using PlaywrightSpecFlow.Configuration.Settings.Models;

namespace PlaywrightSpecFlow.Configuration.Drivers
{
    public class BrowserService : IBrowserService
    {
        private const int DefaultTimeout = 30000;

        private readonly PlaywrightSettings _playwrightSettings;

        public BrowserService(ISettings settings)
        {
            _playwrightSettings = settings.PlaywrightSettings;
        }

        public async Task<IBrowser> GetBrowserAsync(IPlaywright playwright, string browserName)
        {
            BrowserTypeLaunchOptions options;
            string browserType;
            switch (browserName)
            {
                case "chrome":
                    browserType = BrowserType.Chromium;
                    options = GetOptions(_playwrightSettings.Args, _playwrightSettings.DefaultTimeout, _playwrightSettings.Headless, _playwrightSettings.SlowMo);
                    options.Channel = "chrome";
                    break;
                case "edge":
                    browserType = BrowserType.Chromium;
                    options = GetOptions(_playwrightSettings.Args, _playwrightSettings.DefaultTimeout, _playwrightSettings.Headless, _playwrightSettings.SlowMo);
                    options.Channel = "msedge";
                    break;
                default:
                    throw new NotSupportedException($"Browser {browserName} not supported!");
            }

            return await playwright[browserType].LaunchAsync(options).ConfigureAwait(false);
        }

        private BrowserTypeLaunchOptions GetOptions(string[]? args, int? timeout = DefaultTimeout, bool? headless = true, int? slowMo = null)
            => new() { Args = args, Timeout = timeout, Headless = headless, SlowMo = slowMo };
    }
}
