using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalDevelopment.Interfaces
{
    public interface IMemoryUser : IUser
    {
        #region Properties
        string LoginName { get; set; }
        string Password { get; set; }
        [EmailAddress]
        string Email { get; set; }
        DateTime DateOfBirth { get; set; }
        #endregion
    }
}