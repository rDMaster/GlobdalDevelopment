using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IErrorPackage : IPackage
    {
        string Message { get; set; }
        int Code { get; set; }
    }
}
