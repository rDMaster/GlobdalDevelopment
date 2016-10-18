using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPlatformSource
    {
        /// <summary>
        /// Height of the image.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// The URL of the image.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// With of the image.
        /// </summary>
        public int Width { get; set; }
        public FacebookPlatformSource(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Height = int.Parse((obj["height"] ?? "100").ToString());
            Source = (obj["source"] ?? "100").ToString();
            Width = int.Parse((obj["width"] ?? "100").ToString());
        }
    }
}
