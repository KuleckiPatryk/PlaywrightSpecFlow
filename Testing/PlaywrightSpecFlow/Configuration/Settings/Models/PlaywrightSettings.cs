namespace PlaywrightSpecFlow.Configuration.Settings.Models
{
    public class PlaywrightSettings
    {
        public string BrowserName { get; set; }

        public bool Headless { get; set; }

        public string[]? Args { get; set; }

        public int? SlowMo { get; set; }

        public int? DefaultTimeout { get; set; }
    }
}
