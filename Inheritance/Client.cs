using GlobalDevelopment.Packages;
using GlobalDevelopment.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using GlobalDevelopment.Interfaces;

namespace GlobalDevelopment.Inheritance
{
    public class Client : IClient
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
        protected virtual bool OnLogUpdated()
        {
            OnLogUpdate?.Invoke(this, EventArgs.Empty);
            return true;
        }
        #endregion
        #region Properties
        public enum Types
        {
            Tcp = 100,
            Udp = 101
        }
        public Types Type { get; set; }
        public int _BufferSize { get; set; }
        public byte[] _Buffer { get; set; }
        public Socket ClientSocket { get; set; }
        public Socket BroadcastSocket { get; set; }
        public IPEndPoint LocalEndPoint { get; set; }
        public IPEndPoint BroadcastEndPoint { get; set; }
        public IPEndPoint ServerEndPoint { get; set; }
        public bool IsIpv6 { get; set; }
        public int Port { get; set; }
        public List<ILogPackage> Log { get; set; }
        public List<IMessagePackage> Messages { get; set; }
        public List<IPackage> MessagesAllInOne { get; set; }
        public List<IBroadCastPackage> BroadcastMessages { get; set; }
        public IPAddress IpAddress { get; set; }
        #endregion
        #region Constructors
        public Client(bool isIpv6, string ip, int port)
        {
            IsIpv6 = isIpv6;
            Port = port;
            Log = new List<ILogPackage>();
            Messages = new List<IMessagePackage>();
            MessagesAllInOne = new List<IPackage>();
            BroadcastMessages = new List<IBroadCastPackage>();
            if (IsIpv6)
            {
                IpAddress = NetworkHelper.GetMyIpv6IPaddress();
                LocalEndPoint = NetworkHelper.CreateIpv6EndPoint(IpAddress, Port);
                ServerEndPoint = NetworkHelper.CreateIpv6EndPoint(ip, Port);
                BroadcastEndPoint = NetworkHelper.CreateIpv6EndPoint(ip, Port + 1000);
            }
            else
            {
                IpAddress = NetworkHelper.GetMyIpv4IPaddress();
                LocalEndPoint = NetworkHelper.CreateIpv4EndPoint(IpAddress, Port);
                ServerEndPoint = NetworkHelper.CreateIpv4EndPoint(ip, Port);
                BroadcastEndPoint = NetworkHelper.CreateIpv4EndPoint(ip, Port + 1000);
            }
        }
        #endregion
    }
}