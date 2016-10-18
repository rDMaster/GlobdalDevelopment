using GlobalDevelopment.SocialNetworks.LinkedIn.Models;

namespace GlobalDevelopment.SocialNetworks.LinkedIn
{
    public class LinkedInM
    {
        public LinkedInApp App { get; set; }
        public LinkedInUser User { get; set; }
        public LinkedInM(string appID, string appSecret, string returnUrl)
        {
            App = new LinkedInApp(appID, appSecret, returnUrl);
            User = new LinkedInUser(appID, appSecret, returnUrl);
        }
        public LinkedInM(string accessToken)
        {
            App = new LinkedInApp(accessToken);
            User = new LinkedInUser(accessToken);
        }
    }
}
