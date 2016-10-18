using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookProfile
    {
        public FacebookUser UserProfile { get; set; }
        public FacebookPage PageProfile { get; set; }
        public FacebookGroup GroupProfile { get; set; }
        public FacebookApp AppProfile { get; set; }
        public FacebookProfile(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            UserProfile = (object)obj as FacebookUser;
            PageProfile = (object)obj as FacebookPage;
            GroupProfile = (object)obj as FacebookGroup;
            AppProfile = (object)obj as FacebookApp;
            if (UserProfile != null)
                UserProfile = new FacebookUser(token);
            else if (PageProfile != null)
                PageProfile = new FacebookPage(token);
            else if (GroupProfile != null)
                GroupProfile = new FacebookGroup(token);
        }
    }
}
