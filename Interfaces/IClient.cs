using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IClient
    {
        #region Properties
        int _BufferSize { get; set; }
        byte[] _Buffer { get; set; }
        Socket ClientSocket { get; set; }
        Socket BroadcastSocket { get; set; }
        IPEndPoint LocalEndPoint { get; set; }
        IPEndPoint BroadcastEndPoint { get; set; }
        IPEndPoint ServerEndPoint { get; set; }
        bool IsIpv6 { get; set; }
        int Port { get; set; }
        List<ILogPackage> Log { get; set; }
        List<IMessagePackage> Messages { get; set; }
        List<IPackage> MessagesAllInOne { get; set; }
        List<IBroadCastPackage> BroadcastMessages { get; set; }
        IPAddress IpAddress { get; set; }
        #endregion
    }
}