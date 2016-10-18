using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace GlobalDevelopment.Helpers
{
    public static class WebHelper
    {
        public static string QueryBuilder(Dictionary<string,string> queries)
        {
            string queryString = "?";
            foreach(KeyValuePair<string,string> query in queries)
            {
                queryString += query.Key + "=" + query.Value + "&";
            }
            return (queryString.Substring(0, queryString.LastIndexOf("&")));
        }
        public static string GetQueryValue(string perameter)
        {
            return HttpContext.Current.Request[perameter].ToString();
        }
        public static string ReadResponse(HttpWebResponse response)
        {
            try
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch(WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                return reader.ReadToEnd();
            }
        }
        public static string ReadResponse(WebResponse response)
        {
            try
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (WebException er)
            {
                StreamReader reader = new StreamReader(er.Response.GetResponseStream());
                return reader.ReadToEnd();
            }
        }
    }
}
