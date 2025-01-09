namespace PlaywrightSpecFlow.Configuration.Settings.Models
{
    public class Settings : ISettings
    {
        public string BaseUrl { get; set; }

        public string ApiUrl { get; set; }

        public UsersSettings UsersSettings { get; set; }

        public PlaywrightSettings PlaywrightSettings { get; set; }
    }
}
