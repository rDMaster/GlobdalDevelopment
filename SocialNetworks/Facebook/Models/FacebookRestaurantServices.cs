using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookRestaurantServices
    {
        /// <summary>
        /// Whether restaurant has catering service.
        /// </summary>
        public int Catering { get; set; }
        /// <summary>
        /// Whether restaurant has delivery service.
        /// </summary>
        public int Delivery { get; set; }
        /// <summary>
        /// Whether restaurant is group-friendly.
        /// </summary>
        public int Groups { get; set; }
        /// <summary>
        /// Whether the restaurant is kid-friendly.
        /// </summary>
        public int Kids { get; set; }
        /// <summary>
        /// Whether the restaurant has outdoor seating.
        /// </summary>
        public int Outdoor { get; set; }
        /// <summary>
        /// Whether the restaurant takes reservations.
        /// </summary>
        public int Reserver { get; set; }
        /// <summary>
        /// Whether restaurant has takeout service.
        /// </summary>
        public int Takeout { get; set; }
        /// <summary>
        /// whether the restaurant has takeout service.
        /// </summary>
        public int Waiter { get; set; }
        /// <summary>
        /// Whether the restaurant welcomes walkins.
        /// </summary>
        public int Walkins { get; set; }
        public FacebookRestaurantServices(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Catering = int.Parse((obj["catering"] ?? "0").ToString());
            Delivery = int.Parse((obj["delivery"] ?? "0").ToString());
            Groups = int.Parse((obj["groups"] ?? "0").ToString());
            Kids = int.Parse((obj["kids"] ?? "0").ToString());
            Outdoor = int.Parse((obj["outdoor"] ?? "0").ToString());
            Reserver = int.Parse((obj["reserve"] ?? "0").ToString());
            Takeout = int.Parse((obj["takeout"] ?? "0").ToString());
            Waiter = int.Parse((obj["waiter"] ?? "0").ToString());
            Walkins = int.Parse((obj["walkins"] ?? "0").ToString());
        }
    }
}
