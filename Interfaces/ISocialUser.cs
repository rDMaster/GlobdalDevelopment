using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface ISocialUser : IUser
    {
        string ProfileUrl { get; set; }
        Image Image { get; set; }
        List<ISocialUser> Friends { get; set; }
        List<IPost> Posts { get; set; }
    }
}