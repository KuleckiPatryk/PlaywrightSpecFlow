using PlaywrightSpecFlow.Configuration.Settings.Models;

namespace PlaywrightSpecFlow.Configuration.Settings
{
    public interface ISettings
    {
        string BaseUrl { get; }

        string ApiUrl { get; }

        UsersSettings UsersSettings { get; }

        PlaywrightSettings PlaywrightSettings { get; }
    }
}
