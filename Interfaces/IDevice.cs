using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IDevice
    {
        string Hardware { get; set; }
        string OperatingSystem { get; set; }
    }
}
