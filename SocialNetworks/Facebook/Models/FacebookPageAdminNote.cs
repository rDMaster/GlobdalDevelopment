using GlobalDevelopment.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPageAdminNote
    {
        /// <summary>
        /// Content of this note.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// ID othe tag.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// The user that this note is attached to.
        /// </summary>
        public FacebookUser User { get; set; }
        public FacebookPageAdminNote(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Body = (obj["body"] ?? "NA").ToString();
            ID = (obj["id"] ?? "NA").ToString();
            Body = (obj["body"] ?? "NA").ToString();
            if (HttpContext.Current.Session[FacebookApi.SessionApp] != null)
            {
                var app = (FacebookApp)HttpContext.Current.Session[FacebookApi.SessionApp];
                User = new FacebookUser(app.AccessToken);
            } else
            {
                User = null;
            }
        }
    }
}
