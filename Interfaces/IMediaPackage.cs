using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IMediaPackage : IPackage
    {
        byte[] Data { get; set; }
        Image Image { get; set; }
    }
}
