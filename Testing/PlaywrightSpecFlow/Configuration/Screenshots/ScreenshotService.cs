using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace PlaywrightSpecFlow.Configuration.Screenshots
{
    public class ScreenshotService : IScreenshotService
    {
        private readonly IPage _page;

        public ScreenshotService(IPage page)
        {
            _page = page;
        }

        public async Task TakeScreenshot(TestContext testContext)
        {
            if (testContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var filePath = $"{TestContext.CurrentContext.Test.Name}.png";
                await _page.ScreenshotAsync(new PageScreenshotOptions
                {
                    FullPage = true,
                    Path = filePath
                }).ConfigureAwait(false);

                TestContext.AddTestAttachment(filePath);
            }
        }
    }
}
