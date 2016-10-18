using GlobalDevelopment.Interfaces;
using System;

namespace GlobalDevelopment.Models
{
    public class Page : IPage
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}