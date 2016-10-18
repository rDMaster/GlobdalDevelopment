using GlobalDevelopment.Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface ILogPackage : IPackage
    {
        string Message { get; set; }
        DateTime Time { get; set; }
    }
}
