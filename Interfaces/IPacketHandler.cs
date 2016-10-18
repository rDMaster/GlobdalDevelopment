using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IPacketHandler
    {
        #region Propertiers
        List<object> Packages { get; set; }
        List<int> Types { get; set; }
        #endregion
        #region Methods
        byte[] HandleSend();
        List<IPackageEntry> HandleReceive();
        #endregion
    }
}
