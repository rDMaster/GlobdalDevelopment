using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IRequestPackage : IPackage
    {
        byte[] Data { get; set; }
    }
}
