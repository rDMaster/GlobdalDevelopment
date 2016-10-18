using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IServer
    {
        #region Properties
        int Port { get; set; }
        bool IsIpv6 { get; set; }
        byte[] _Buffer { get; set; }
        IPEndPoint ServerEndPoint { get; set; }
        IPEndPoint BroadcastEndPoint { get; set; }
        Socket ServerSocket { get; set; }
        Socket BroadcastSocket { get; set; }
        List<ILogPackage> Log { get; set; }
        List<IMessagePackage> Messages { get; set; }
        List<IPackage> MessagesAllInOne { get; set; }
        List<IBroadCastPackage> BroadcastMessages { get; set; }
        #endregion
    }
}