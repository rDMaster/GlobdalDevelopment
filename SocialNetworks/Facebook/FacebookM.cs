using GlobalDevelopment.Helpers;
using GlobalDevelopment.OAuth.Models;
using GlobalDevelopment.SocialNetworks.Facebook.Interfaces;
using GlobalDevelopment.SocialNetworks.Facebook.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace GlobalDevelopment.SocialNetworks.Facebook
{
    public class FacebookM
    {
        public FacebookApp App { get; set; }
        public FacebookUser User { get; set; }
        public FacebookM(string appID, string appSecret, string returnUrl)
        {
            App = new FacebookApp(appID, appSecret, returnUrl);
            User = new FacebookUser(appID, appSecret, returnUrl);
        }
        public FacebookM(string accessToken)
        {
            App = new FacebookApp(accessToken);
            User = new FacebookUser(accessToken);
        }
    }
}