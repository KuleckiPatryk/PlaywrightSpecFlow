using Microsoft.Playwright;

namespace PlaywrightSpecFlow.Helpers
{
    public static class ResponseExtensions
    {
        public static bool CheckResponse(this IResponse response, string url, int statusCode, string method)
        {
            return response.Url.Contains(url) && response.Status == statusCode && response.Request.Method == method;
        }

        public static bool CheckResponse(this IResponse response, int statusCode, string method)
        {
            return response.Status == statusCode && response.Request.Method == method;
        }
    }
}
