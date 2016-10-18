using GlobalDevelopment.SocialNetworks.LinkedIn.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace GlobalDevelopment.Helpers
{
    public static class LinkedInHelper
    {
        public static TokenInformation Authorization(string url, string appID, string appSecret, string permissionScope, string state, string grantType)
        {
            TokenInformation accessInformation = new TokenInformation();
            accessInformation.AccessToken = "Invalid AccessToken";

            Dictionary<string, string> QueryString = new Dictionary<string, string>();
            QueryString.Add("response_type", "code");
            QueryString.Add("client_id", appID);
            QueryString.Add("redirect_uri", url);
            QueryString.Add("state", state);
            QueryString.Add("scope", permissionScope);

            if (HttpContext.Current.Request["code"] == null)
            {
                HttpContext.Current.Response.Redirect(LinkedInApi.AuthorizeUrl + WebHelper.QueryBuilder(QueryString));
            }
            else
            {
                Dictionary<string, string> ResponseQueryString = new Dictionary<string, string>();
                ResponseQueryString.Add("grant_type", grantType);
                ResponseQueryString.Add("code", WebHelper.GetQueryValue("code"));
                ResponseQueryString.Add("redirect_uri", url);
                ResponseQueryString.Add("client_id", appID);
                ResponseQueryString.Add("client_secret", appSecret);
                Dictionary<string, string> Tokens = new Dictionary<string, string>();
                string responseUrl = LinkedInApi.AccessTokenUrl + WebHelper.QueryBuilder(ResponseQueryString);
                HttpWebRequest request = WebRequest.Create(responseUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    string vals = WebHelper.ReadResponse(response);
                    if (vals.IndexOf("&") != -1)
                    {
                        foreach (string token in vals.Split('&'))
                        {
                            Tokens.Add(token.Substring(0, token.IndexOf("=")),
                                token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                        }
                    } else
                    {
                        var data = (JObject)JsonConvert.DeserializeObject(vals);
                        Tokens.Add("access_token", data["access_token"].Value<string>());
                        Tokens.Add("expires_in", data["expires_in"].Value<string>());
                    }
                }
                accessInformation.AccessToken = Tokens["access_token"];
                accessInformation.ExpiresIn = Tokens["expires_in"];
            }

            return accessInformation;
        }
        public static JObject GetUser(string accessToken)
        {
            JObject UserJson = null;
            HttpWebRequest request = WebRequest.Create(LinkedInApi.UserUrl + accessToken + LinkedInApi.FormatUrl) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                string vals = WebHelper.ReadResponse(response);
                UserJson = JObject.Parse(vals);
            }
            return UserJson;
        }
    }
}
