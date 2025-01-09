using Microsoft.Playwright;

namespace PlaywrightSpecFlow.Helpers
{
    public static class PageExtensions
    {
        public static async Task WaitForResponse(this IPage page, string url, string method, int statusCode) =>
            await page.WaitForResponseAsync(r => r.Url.Contains(url) && r.Status == statusCode && r.Request.Method == method).ConfigureAwait(false);
    }
}
