using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IPackageEntry
    {
        int Type { get; set; }
        byte[] Data { get; set; }
        Guid PackageId { get; set; }
        int priority { get; set; }
    }
}