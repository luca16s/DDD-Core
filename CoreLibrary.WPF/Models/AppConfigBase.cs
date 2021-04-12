namespace CoreLibrary.Wpf.Models
{
    public class AppConfig
    {
        public string UserFileName { get; set; }
        public string IdentityClientId { get; set; }
        public string PrivacyStatement { get; set; }
        public string ConfigurationsFolder { get; set; }
        public string AppPropertiesFileName { get; set; }
        public string IdentityCacheFileName { get; set; }
        public string IdentityCacheDirectoryName { get; set; }

        public Secret SelectedSecret => /*Dropbox ?? */OneDrive;

        public Secret Dropbox { get; set; }
        public Secret OneDrive { get; set; }
    }

    public class Secret
    {
        public string AppKey { get; set; }
        public string Service { get; set; }
        public string AppToken { get; set; }
        public string AppSecret { get; set; }

        public string Endpoint { get; set; }
        public string RedirectEndpoint { get; set; }
        public string JsRedirectEntpoint { get; set; }
    }
}