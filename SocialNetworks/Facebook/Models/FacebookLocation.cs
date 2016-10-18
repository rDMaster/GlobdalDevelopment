using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookLocation
    {
        public string City { get; set; }
        public string CityID { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public float Latitude { get; set; }
        public string LocatedIn { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public int RegionID { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public FacebookLocation(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            City = (obj["city"] ?? "NA").ToString();
            CityID = (obj["city_id"] ?? "NA").ToString();
            Country = (obj["country"] ?? "NA").ToString();
            CountryCode = (obj["country_code"] ?? "NA").ToString();
            Latitude = float.Parse((obj["latitude"] ?? "NA").ToString());
            LocatedIn = (obj["located_in"] ?? "NA").ToString();
            Longitude = float.Parse((obj["longitude"] ?? "NA").ToString());
            Name = (obj["name"] ?? "NA").ToString();
            Region = (obj["region"] ?? "NA").ToString();
            RegionID = int.Parse((obj["region_id"] ?? "NA").ToString());
            State = (obj["state"] ?? "NA").ToString();
            Street = (obj["street"] ?? "NA").ToString();
            Zip = (obj["zip"] ?? "NA").ToString();
        }
    }
}