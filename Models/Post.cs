using GlobalDevelopment.Interfaces;
using System;

namespace GlobalDevelopment.Models
{
    public class Posts : IPost
    {
        public string postMessage { get; set; }
        public string ImageSrc { get; set; }
        public string PostUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OwnerName { get; set; }
    }
}