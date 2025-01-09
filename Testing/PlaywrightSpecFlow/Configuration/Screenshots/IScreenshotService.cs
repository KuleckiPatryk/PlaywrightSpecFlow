using NUnit.Framework;

namespace PlaywrightSpecFlow.Configuration.Screenshots
{
    public interface IScreenshotService
    {
        Task TakeScreenshot(TestContext testContext);
    }
}
