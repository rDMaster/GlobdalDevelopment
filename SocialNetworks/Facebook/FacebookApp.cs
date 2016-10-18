using GlobalDevelopment.OAuth.Models;
using GlobalDevelopment.SocialNetworks.Facebook.Models;
using System.Web;

namespace GlobalDevelopment.SocialNetworks.Facebook
{
    public class FacebookApp : OAuthApp
    {
        public FacebookApp(string appId, string appSecret, string returnUrl) : base(appId, appSecret, FacebookApi.Permission, returnUrl)
        {
            HttpContext.Current.Session[FacebookApi.SessionApp] = this as OAuthApp;
        }
        public FacebookApp(string accessToken) : base((OAuthApp)HttpContext.Current.Session[FacebookApi.SessionApp])
        {
            FacebookApp app = (OAuthApp)HttpContext.Current.Session[FacebookApi.SessionApp] as FacebookApp;
            AppID = app.AppID;
            AppSecret = app.AppSecret;
            AccessToken = app.AccessToken;
        }
    }
}