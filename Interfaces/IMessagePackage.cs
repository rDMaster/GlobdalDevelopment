using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IMessagePackage : IPackage
    {
        #region Properties
        string Message { get; set; }
        string To { get; set; }
        string From { get; set; }
        DateTime Sent { get; set; }
        DateTime Received { get; set; }
        #endregion
    }
}