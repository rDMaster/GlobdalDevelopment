using GlobalDevelopment.SocialNetworks.Facebook.Interfaces;
using GlobalDevelopment.SocialNetworks.Facebook.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlobalDevelopment.Helpers
{
    public static class FacebookHelper
    {
        public static string Get(string id, string accessToken)
        {
            string json = "Error";
            try
            {
                HttpWebRequest request = WebRequest.Create(FacebookApi.ResourceUrl + id + "&access_token=" + accessToken) as HttpWebRequest;
                /*using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return json = WebHelper.ReadResponse(response);
                }*/
                return WebHelper.ReadResponse(request.GetResponse());
            }
            catch(WebException er)
            {
                return json = WebHelper.ReadResponse(er.Response);
            }
        }
        public static string GetField(string accessToken, string field)
        {
            string result = "Failed!";
            try
            {
                HttpWebRequest request = WebRequest.Create(FacebookApi.ResourceUrl + "me?fields=" + field + "&access_token=" + accessToken) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string vals = reader.ReadToEnd();
                    string jsonString = vals;
                    JToken ob = null;
                    var json = JObject.Parse(jsonString);
                    if (json.TryGetValue(field, out ob))
                    {
                        result = ob.ToString();
                    }
                }
            } catch(WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            return result;
        }
        public static string GetField(string target, string accessToken, string fields)
        {
            string result = "Failed!";
            try
            {
                HttpWebRequest request = null;
                if(fields == "" || fields == null)
                {
                    request = WebRequest.Create(FacebookApi.ResourceUrl + target + "?access_token=" + accessToken) as HttpWebRequest;
                } else
                {
                    request = WebRequest.Create(FacebookApi.ResourceUrl + target + "?fields=" + fields + "&access_token=" + accessToken) as HttpWebRequest;
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string vals = reader.ReadToEnd();
                    JToken ob = null;
                    var json = JObject.Parse(vals);
                    if (json.TryGetValue(fields, out ob))
                    {
                        result = ob.ToString();
                    } else
                    {
                        result = json.ToString();
                    }
                }
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            return result;
        }
        public static string GetFieldJson(string accessToken, string fields)
        {
            string result = "Failed!";
            try
            {
                HttpWebRequest request = null;
                if (fields == "" || fields == null)
                {
                    request = WebRequest.Create(FacebookApi.ResourceUrl + "me" + "?access_token=" + accessToken) as HttpWebRequest;
                }
                else
                {
                    request = WebRequest.Create(FacebookApi.ResourceUrl + "me" + "?fields=" + fields + "&access_token=" + accessToken) as HttpWebRequest;
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            return result;
        }
        public static string GetFieldJson(string target, string accessToken, string fields)
        {
            string result = "Failed!";
            try
            {
                HttpWebRequest request = null;
                if (fields == "" || fields == null)
                {
                    request = WebRequest.Create(FacebookApi.ResourceUrl + target + "?access_token=" + accessToken) as HttpWebRequest;
                }
                else
                {
                    request = WebRequest.Create(FacebookApi.ResourceUrl + target + "?fields=" + fields + "&access_token=" + accessToken) as HttpWebRequest;
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            return result;
        }
        public static string GetEdge(string id, string edge)
        {
            WebResponse response = null;
            string result = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format(FacebookApi.ResourceUrl + "{0}/" + edge, id));
                response = request.GetResponse();
                result = response.ResponseUri.ToString();
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            finally
            {
                if (response != null) response.Close();
            }
            return result;
        }
        public static string GetEdge(string id, string edge, string accessToken)
        {
            WebResponse response = null;
            string result = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format(FacebookApi.ResourceUrl + "{0}/" + edge + "?access_token=" + accessToken, id));
                response = request.GetResponse();
                result = response.ResponseUri.ToString();
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            finally
            {
                if (response != null) response.Close();
            }
            return result;
        }
        public static string GetEdgeJson(string id, string edge)
        {
            WebResponse response = null;
            string result = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format(FacebookApi.ResourceUrl + "{0}/" + edge, id));
                response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            finally
            {
                if (response != null) response.Close();
            }
            return result;
        }
        public static string GetEdgeJson(string id, string edge, string accessToken)
        {
            WebResponse response = null;
            string result = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format(FacebookApi.ResourceUrl + "{0}/" + edge + "?access_token=" + accessToken, id));
                response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            finally
            {
                if (response != null) response.Close();
            }
            return result;
        }
        public static string GetEdgeJson(string id, string edge, string fields, string accessToken)
        {
            WebResponse response = null;
            string result = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format(FacebookApi.ResourceUrl + "{0}/" + edge + "?fields=" + fields + "&access_token=" + accessToken, id));
                response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                string vals = reader.ReadToEnd();
                result = vals;
            }
            finally
            {
                if (response != null) response.Close();
            }
            return result;
        }
        public static string Authorization(string url, string appID, string appSecret, string permissionScope)
        {
            string accessToken = "Invalid AccessToken";

            Dictionary<string, string> QueryString = new Dictionary<string, string>();
            QueryString.Add("client_id", appID);
            QueryString.Add("redirect_uri", url);
            QueryString.Add("scope", permissionScope);

            if(HttpContext.Current.Request["code"] == null)
            {
                HttpContext.Current.Response.Redirect(FacebookApi.AuthorizeUrl + WebHelper.QueryBuilder(QueryString));
            } else
            {
                QueryString.Add("code", WebHelper.GetQueryValue("code"));
                QueryString.Add("client_secret", appSecret);

                Dictionary<string, string> Tokens = new Dictionary<string, string>();
                string responseUrl = FacebookApi.AccessTokenUrl + WebHelper.QueryBuilder(QueryString);
                HttpWebRequest request = WebRequest.Create(responseUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    string vals = WebHelper.ReadResponse(response);
                    foreach (string token in vals.Split('&'))
                    {
                        Tokens.Add(token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                    }
                }
                accessToken = Tokens["access_token"];
            }

            return accessToken;
        }
        public static JObject GetUser(string accessToken)
        {
            JObject UserJson = null;
            HttpWebRequest request = WebRequest.Create(FacebookApi.ResourceUrl + "me?fields=" + FacebookApi.UserFields + "&access_token=" + accessToken) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                string vals = WebHelper.ReadResponse(response);
                UserJson = JObject.Parse(vals);
            }
            return UserJson;
        }
        public static JObject GetUser(string id, string accessToken)
        {
            JObject UserJson = null;
            HttpWebRequest request = WebRequest.Create(FacebookApi.ResourceUrl + id +"?fields=" + FacebookApi.UserFields + "&access_token=" + accessToken) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                string vals = WebHelper.ReadResponse(response);
                UserJson = JObject.Parse(vals);
            }
            return UserJson;
        }
    }
}
