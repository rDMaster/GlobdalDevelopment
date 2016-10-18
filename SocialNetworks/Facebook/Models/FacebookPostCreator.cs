using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPostCreator
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public FacebookPostCreator(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}