using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookParking
    {
        /// <summary>
        /// Whether lot parking is available.
        /// </summary>
        public int Lot { get; set; }
        /// <summary>
        /// Whether street parking is available.
        /// </summary>
        public int Street { get; set; }
        /// <summary>
        /// Whether valet parking is available.
        /// </summary>
        public int Valet { get; set; }
        public FacebookParking(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Lot = int.Parse((obj["lot"] ?? "0").ToString());
            Street = int.Parse((obj["street"] ?? "0").ToString());
            Valet = int.Parse((obj["valet"] ?? "0").ToString());
        }
    }
}
