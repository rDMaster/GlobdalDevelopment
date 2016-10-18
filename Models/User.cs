using GlobalDevelopment.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Models
{
    public class User : IUser
    {
        public string UserName { get; set; }
        public string ID { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FullName; } set { FullName = FirstName + " " + LastName; } }
        public string Email { get; set; }
        public User()
        {
            Guid = Guid.NewGuid();
        }
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}