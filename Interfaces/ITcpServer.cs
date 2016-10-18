using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface ITcpServer : IServer
    {
        #region Properties
        int BufferSize { get; set; }
        List<Clients.TcpClient> Clients { get; set; }
        List<IMediaPackage> Files { get; set; }
        Socket ClientSocket { get; set; }
        #endregion
        #region Methods
        void Start(int backlog);
        void Accept();
        void Stop(bool reuse);
        void Send(byte[] data);
        void SendTo(byte[] data);
        void Broadcast(string message);
        #endregion
        #region Data handling methods
        void HandleRequest(byte[] data);
        void HandleDisconnection(byte[] data);
        void ConnectRequest(byte[] data);
        void HandleUpdateClients(byte[] data);
        void HandleUpdateClients();
        void HandleBroadcast(byte[] data);
        void HandleLog(byte[] data);
        void HandleMessage(byte[] data);
        void HandleFile(byte[] data);
        #endregion
        #region Callbacks
        void AcceptCallBack(IAsyncResult ar);
        void ReceiveCallBack(IAsyncResult ar);
        void SendCallBack(IAsyncResult ar);
        #endregion
    }
}