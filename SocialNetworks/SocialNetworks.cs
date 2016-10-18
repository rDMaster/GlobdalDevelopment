using GlobalDevelopment.SocialNetworks.Facebook;
using GlobalDevelopment.SocialNetworks.LinkedIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks
{
    public class SocialNetworks
    {
        public FacebookM FacebookSession { get; set; }
        public LinkedInM LinkedinSession { get; set; }
        public void CreateFacebookSession(string appID, string appSecret, string returnUrl)
        {
            FacebookSession = new FacebookM(appID, appSecret, returnUrl);
        }
        public void CreateLinkedinSession(string appID, string appSecret, string returnUrl)
        {
            LinkedinSession = new LinkedInM(appID, appSecret, returnUrl);
        }
    }
}