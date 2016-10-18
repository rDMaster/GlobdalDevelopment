using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookRestaurantSpecialties
    {
        /// <summary>
        /// Whether restaurant serves breakfast.
        /// </summary>
        public int Breakfast { get; set; }
        /// <summary>
        /// Whether the restaurant serves coffee.
        /// </summary>
        public int Coffee { get; set; }
        /// <summary>
        /// Whether the restaurant serves dinner.
        /// </summary>
        public int Dinner { get; set; }
        /// <summary>
        /// Whether the restaurant serves Drinks.
        /// </summary>
        public int Drinks { get; set; }
        /// <summary>
        /// Whether the restaurant serves lunch.
        /// </summary>
        public int Lunch { get; set; }
        public FacebookRestaurantSpecialties(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Breakfast = int.Parse((obj["breakfast"] ?? "0").ToString());
            Coffee = int.Parse((obj["coffee"] ?? "0").ToString());
            Dinner = int.Parse((obj["dinner"] ?? "0").ToString());
            Drinks = int.Parse((obj["drinks"] ?? "0").ToString());
            Lunch = int.Parse((obj["lunch"] ?? "0").ToString());
        }
    }
}