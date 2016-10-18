using GlobalDevelopment.OAuth.Models;
using GlobalDevelopment.SocialNetworks.LinkedIn.Models;
using System.Web;

namespace GlobalDevelopment.SocialNetworks.LinkedIn
{
    public class LinkedInApp : OAuthApp
    {
        public TokenInformation TI { get; set; }
        public LinkedInApp(string appID, string appSecret, string returnUrl) : base(appID, appSecret, LinkedInApi.Permission, returnUrl)
        {
            HttpContext.Current.Session[LinkedInApi.SessionApp] = this as OAuthApp;
        }
        public LinkedInApp(string accessToken) : base((OAuthApp)HttpContext.Current.Session[LinkedInApi.SessionApp])
        {
            LinkedInApp app = (OAuthApp)HttpContext.Current.Session[LinkedInApi.SessionApp] as LinkedInApp;
            if (TI != null)
            {
                AccessToken = TI.AccessToken;
                ExpiresIn = TI.ExpiresIn;
            }
            else
            {
                AppID = app.AppID;
                AppSecret = app.AppSecret;
                AccessToken = app.AccessToken;
            }
        }
    }
}
