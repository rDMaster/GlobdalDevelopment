using GlobalDevelopment.Interfaces;
using System;
using System.Collections.Generic;

namespace GlobalDevelopment.Models
{
    public class Month : IEquatable<IMonth>
    {
        public Month()
        {
            Days = new List<IDay>();
        }
        public static string[] MonthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "November", "December" };
        public void AddUniquePage<Page>(IPage item)
        {
            var items = this.Pages;
            if (items.Count == 0)
            {
                items.Add(item);
            }
            else
            {
                if (items.IndexOf(item) == -1)
                {
                    items.Add(item);
                    items.DistinctByKey(p => item);
                }
            }
        }
        public string Name { get; set; }
        public List<IPage> Pages { get; set; }
        public List<IDay> Days { get; set; }
        public bool Equals(IMonth other)
        {
            if (this.Name != other.Name && this.Pages != other.Pages && this.Days != other.Days)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}