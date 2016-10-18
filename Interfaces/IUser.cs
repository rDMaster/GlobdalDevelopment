using System;

namespace GlobalDevelopment.Interfaces
{
    public interface IUser
    {
        Guid Guid { get; set; }
        string ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string FullName { get; set; }
    }
}