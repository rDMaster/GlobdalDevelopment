using GlobalDevelopment.Helpers;
using GlobalDevelopment.OAuth.Models;
using GlobalDevelopment.SocialNetworks.LinkedIn.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlobalDevelopment.SocialNetworks.LinkedIn
{
    public class LinkedInUser
    {
        public bool IsAuthenticated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FormattedName { get; set; }
        public string Industry { get; set; }
        public string ID { get; set; }
        public Location Location { get; set; }
        public string Headline { get; set; }
        public string NumConnections { get; set; }
        public string NumConnectionsCapped { get; set; }
        public Positions Positions { get; set; }
        public ApiStandardProfileRequest ApiStandardProfileRequest { get; set; }
        public SiteStandardProfileRequestUrl SiteStandardProfileRequestUrl { get; set; }
        public string PictureUrl { get; set; }
        public string PictureUrls { get; set; }
        public string PublicProfileUrl { get; set; }
        public LinkedInApp App { get; set; }
        public string AccessToken { get; set; }
        public LinkedInUser(string appID, string appSecret, string returnUrl)
        {
            IsAuthenticated = false;
            if (HttpContext.Current.Session[LinkedInApi.SessionApp] != null)
            {
                App = (OAuthApp)HttpContext.Current.Session[LinkedInApi.SessionApp] as LinkedInApp;
                if (App.AccessToken == null || App.AccessToken == "Invalid AccessToken")
                    App.TI = LinkedInHelper.Authorization(App.ReturnUrl, appID, appSecret, LinkedInApi.Permission, LinkedInApi.State, LinkedInApi.GrantType);
            }
            else
            {
                App = new LinkedInApp(appID, appSecret, returnUrl);
                if (App.AccessToken == null || App.AccessToken == "Invalid AccessToken")
                {
                    string url = string.Empty;
                    if (returnUrl.IndexOf("?") != -1)
                        url = returnUrl.Substring(0, returnUrl.IndexOf("?"));
                    else
                        url = returnUrl;
                    App.TI = LinkedInHelper.Authorization(url, appID, appSecret, LinkedInApi.Permission, LinkedInApi.State, LinkedInApi.GrantType);
                }
            }
            if(App.TI != null)
            {
                App.AccessToken = App.TI.AccessToken;
                App.ExpiresIn = App.TI.ExpiresIn;
            }
            if (App.AccessToken != null && App.AccessToken != "Invalid AccessToken")
            {
                IsAuthenticated = true;
                AccessToken = App.AccessToken;
                BuildUser(LinkedInHelper.GetUser(AccessToken));
            }
        }
        public LinkedInUser(string accesstoken)
        {
            IsAuthenticated = false;
            if (HttpContext.Current.Session[LinkedInApi.SessionApp] != null)
                App = (OAuthApp)HttpContext.Current.Session[LinkedInApi.SessionApp] as LinkedInApp;
            else
                App = new LinkedInApp(accesstoken);
            IsAuthenticated = true;
            BuildUser(LinkedInHelper.GetUser(accesstoken));
        }
        private void BuildUser(JToken token)
        {
            ApiStandardProfileRequest = new ApiStandardProfileRequest(token["apiStandardProfileRequest"]);
            Email = (token["emailAddress"] ?? "NA").ToString();
            FirstName = (token["firstName"] ?? "NA").ToString();
            FormattedName = (token["formattedName"] ?? "NA").ToString();
            Headline = (token["headline"] ?? "NA").ToString();
            ID = (token["id"] ?? "NA").ToString();
            Industry = (token["industry"] ?? "NA").ToString();
            LastName = (token["lastName"] ?? "NA").ToString();
            Location = new Location(token["location"]);
            NumConnections = (token["numConnections"] ?? "NA").ToString();
            NumConnectionsCapped = (token["numConnectionsCapped"] ?? "NA").ToString();
            PictureUrl = (token["pictureUrl"] ?? "NA").ToString();
            Positions = new Positions(token["positions"]);
            PublicProfileUrl = (token["publicProfileUrl"] ?? "NA").ToString();
            SiteStandardProfileRequestUrl = new SiteStandardProfileRequestUrl(token["siteStandardProfileRequest"]);
        }
        private void BuildUser(string accesstoken)
        {

        }
    }
}
