using GlobalDevelopment.OAuth.Interfaces;

namespace GlobalDevelopment.OAuth.Models
{
    public class OAuthApp : IOAuthApp
    {
        private string PermissionScope { get; set; }
        public string AccessToken { get; set; }
        public string ReturnUrl { get; set; }
        public string AppSecret { get; set; }
        public string ExpiresIn { get; set; }
        public string AppID { get; set; }
        public OAuthApp(string appId, string appSecret, string permissionScope, string returnUrl)
        {
            PermissionScope = permissionScope;
            AppSecret = appSecret;
            AppID = appId;
            ReturnUrl = returnUrl;
        }
        public OAuthApp(OAuthApp app)
        {
            PermissionScope = app.PermissionScope;
            AccessToken = app.AccessToken;
            AppID = app.AppID;
            AppSecret = app.AppSecret;
            ReturnUrl = app.ReturnUrl;
        }
    }
}