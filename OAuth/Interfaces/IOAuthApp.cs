using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.OAuth.Interfaces
{
    public interface IOAuthApp
    {
        string PermissionScope { get; set; }
        string AccessToken { get; set; }
        string AppSecret { get; set; }
        string AppID { get; set; }
    }
}