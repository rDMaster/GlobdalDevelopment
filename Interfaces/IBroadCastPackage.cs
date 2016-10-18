using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IBroadCastPackage : IPackage
    {
        string Message { get; set; }
        string From { get; set; }
        DateTime Sent { get; set; }
        DateTime Delivered { get; set; }
    }
}
