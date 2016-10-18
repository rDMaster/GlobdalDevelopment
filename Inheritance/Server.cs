using GlobalDevelopment.Helpers;
using GlobalDevelopment.Interfaces;
using GlobalDevelopment.Packages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace GlobalDevelopment.Inheritance
{
    public class Server : IServer
    {
        #region Events
        // Event Signatures
        public delegate void ReceiveHandler(object source, EventArgs args);
        public delegate void LogUpdateHandler(object source, EventArgs args);
        // Event Referances
        public event ReceiveHandler OnReceive;
        public event LogUpdateHandler OnLogUpdate;
        // Event Methods
        protected virtual void OnReceived()
        {
            OnReceive?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnLogUpdated()
        {
            OnLogUpdate?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region Enums
        public enum Types
        {
            Tcp = 100,
            Udp = 101
        }
        #endregion
        #region Properties
        public Types Type { get; set; }
        public int Port { get; set; }
        public bool IsIpv6 { get; set; }
        public byte[] _Buffer { get; set; }
        public IPEndPoint ServerEndPoint { get; set; }
        public IPEndPoint BroadcastEndPoint { get; set; }
        public Socket ServerSocket { get; set; }
        public Socket BroadcastSocket { get; set; }
        public List<ILogPackage> Log { get; set; }
        public List<IMessagePackage> Messages { get; set; }
        public List<IPackage> MessagesAllInOne { get; set; }
        public List<IBroadCastPackage> BroadcastMessages { get; set; }
        #endregion
        #region Constructoer
        public Server(bool isIpv6, int port)
        {
            Port = port;
            IsIpv6 = isIpv6;
            Log = new List<ILogPackage>();
            Messages = new List<IMessagePackage>();
            MessagesAllInOne = new List<IPackage>();
            BroadcastMessages = new List<IBroadCastPackage>();
            if (IsIpv6)
            {
                ServerEndPoint = NetworkHelper.CreateIpv6EndPoint(IPAddress.IPv6Any, Port);
                BroadcastEndPoint = NetworkHelper.CreateIpv6EndPoint(NetworkHelper.GetMyIpv4IPaddress(), Port + 5000);
            }
            else
            {
                ServerEndPoint = NetworkHelper.CreateIpv4EndPoint(IPAddress.Any, Port);
                BroadcastEndPoint = NetworkHelper.CreateIpv4EndPoint(NetworkHelper.GetMyIpv4IPaddress(), Port + 5000);
            }
        }
        #endregion
    }
}