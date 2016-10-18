using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookMailingAddress
    {
        /// <summary>
        /// The email address ID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Address city name.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Page representing the address city.
        /// </summary>
        public FacebookPage CityPage { get; set; }
        /// <summary>
        /// Country of the address.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Postal code of the address.
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// Region or state of the address.
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Street address.
        /// </summary>
        public string Street1 { get; set; }
        /// <summary>
        /// Second part of the street address.
        /// </summary>
        public string Street2 { get; set; }
        public FacebookMailingAddress(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            City = (obj["city"] ?? "NA").ToString();
            CityPage = new FacebookPage(obj["city_page"]);
            Country = (obj["country"] ?? "NA").ToString();
            PostCode = (obj["post_code"] ?? "NA").ToString();
            Region = (obj["region"] ?? "NA").ToString();
            Street1 = (obj["street1"] ?? "NA").ToString();
            Street2 = (obj["street2"] ?? "NA").ToString();
        }
    }
}
