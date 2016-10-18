using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookVideoUploadLimits
    {
        /// <summary>
        /// Length.
        /// </summary>
        public Int64 Length { get; set; }
        /// <summary>
        /// Size in mbs.
        /// </summary>
        public Int64 Size { get; set; }
        public FacebookVideoUploadLimits(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Length = Int64.Parse((obj["length"] ?? "0").ToString());
            Size = Int64.Parse((obj["size"] ?? "0").ToString());
        }
    }
}
