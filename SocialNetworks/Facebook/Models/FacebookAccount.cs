using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookAccount
    {
        public string AccessToken { get; set; }
        public string Category { get; set; }
        public List<FacebookPageCategory> CategoryList { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string[] Perms { get; set; }
        public FacebookAccount(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            AccessToken = (obj["access_token"] ?? "NA").ToString();
            Category = (obj["category"] ?? "NA").ToString();
            if (obj["category_list"] != null)
            {
                CategoryList = new List<FacebookPageCategory>();
                foreach (var cat in obj["category_list"])
                {
                    FacebookPageCategory fpc = new FacebookPageCategory(cat);
                    CategoryList.Add(fpc);
                }
            }
            Name = (obj["name"] ?? "NA").ToString();
            ID = (obj["id"] ?? "NA").ToString();
            Perms = (obj["perms"] ?? "NA").ToString().Split(',');
        }
    }
}
