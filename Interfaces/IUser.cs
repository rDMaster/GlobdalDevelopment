using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
