using GlobalDevelopment.Helpers;
using GlobalDevelopment.Inheritance;
using GlobalDevelopment.Interfaces;
using GlobalDevelopment.Packages;
using GlobalDevelopment.Packets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GlobalDevelopment.Clients
{
    public class TcpClient : Client, ITcpClient
    {
        #region Events
        // Event Signatures
        public delegate void ConnectHandler(object source, EventArgs args);
        public delegate void DisconnectHandler(object source, EventArgs args);
        public delegate void OnClientconnect(object source, EventArgs args);
        // Event Handlers
        public event ConnectHandler OnConnect;
        public event DisconnectHandler OnDisconnect;
        public event OnClientconnect OnClientConnect;
        // Event Methods
        protected virtual void OnConnected()
        {
            OnConnect?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDisconnected()
        {
            OnDisconnect?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnClientConnected()
        {
            OnClientConnect?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #region Properties
        public int BufferSize { get; set; }
        public IUserPackage UserInformation { get; set; }
        public List<IUserPackage> Users { get; set; }
        public List<IMediaPackage> Files { get; set; }
        #endregion
        #region Constructors
        public TcpClient(bool isIpv6, string ip, int port, string name, string email, int age, string gender) : base(isIpv6, ip, port)
        {
            Type = Types.Tcp;
            UserInformation = new UserPackage(name, email, age, gender);
            Users = new List<IUserPackage>();
            Files = new List<IMediaPackage>();
            if (BufferSize == 0)
                BufferSize = 5000000;
            _Buffer = new byte[BufferSize];
            if (IsIpv6)
            {
                ClientSocket = NetworkHelper.CreateDefaultIpv6TcpSocket();
                BroadcastSocket = NetworkHelper.CreateDefaultIpv6TcpSocket();
            }
            else
            {
                ClientSocket = NetworkHelper.CreateDefaultIpv4TcpSocket();
                BroadcastSocket = NetworkHelper.CreateDefaultIpv4TcpSocket();
            }
        }
        public TcpClient(bool isIpv6, string ip, int port, IUserPackage UserData) : base(isIpv6, ip, port)
        {
            Type = Types.Tcp;
            UserInformation = UserData;
            Users = new List<IUserPackage>();
            Files = new List<IMediaPackage>();
            if (BufferSize == 0)
                BufferSize = 5000000;
            _Buffer = new byte[BufferSize];
            if (IsIpv6)
            {
                ClientSocket = NetworkHelper.CreateDefaultIpv6TcpSocket();
                BroadcastSocket = NetworkHelper.CreateDefaultIpv6TcpSocket();
            }
            else
            {
                ClientSocket = NetworkHelper.CreateDefaultIpv4TcpSocket();
                BroadcastSocket = NetworkHelper.CreateDefaultIpv4TcpSocket();
            }
        }
        public TcpClient(bool isIpv6, IPEndPoint ServerEndPoint, IUserPackage UserData) : base(isIpv6, ServerEndPoint.Address.ToString(), ServerEndPoint.Port)
        {
            Type = Types.Tcp;
            UserInformation = UserData;
            Users = new List<IUserPackage>();
            Files = new List<IMediaPackage>();
            if (BufferSize == 0)
                BufferSize = 5000000;
            _Buffer = new byte[BufferSize];
            if (IsIpv6)
            {
                ClientSocket = NetworkHelper.CreateDefaultIpv6TcpSocket();
                BroadcastSocket = NetworkHelper.CreateDefaultIpv6TcpSocket();
            }
            else
            {
                ClientSocket = NetworkHelper.CreateDefaultIpv4TcpSocket();
                BroadcastSocket = NetworkHelper.CreateDefaultIpv4TcpSocket();
            }
        }
        #endregion
        #region Methods
        public void Connect()
        {
            try
            {
                ClientSocket.BeginConnect(ServerEndPoint, new AsyncCallback(ConnectCallBack), ClientSocket);
            }
            catch (SocketException er)
            {
                Log.Add(new LogPackage("Client | Connect | Socket Exception: " + er.Message + " Code: " + er.NativeErrorCode));
                OnLogUpdated();
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | Connect | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        public void Disconnect(bool reuse)
        {
            List<object> list = new List<object>();
            IRequestPackage Request = new RequestPackage(RequestPackage.RequestTypes.Get, UserInformation.ToByteArray(), RequestPackage.RequestMethods.Disconnect);
            list.Add(Request);
            Send(CastingHelper.ObjectListToByteArray(list));
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Disconnect(reuse);
            if (!ClientSocket.Connected)
                OnDisconnected();
        }
        public void Send(byte[] data)
        {
            IPacketHandler Handler = new PacketHandler(data);
            byte[] dataBuffer = Handler.HandleSend();
            ClientSocket.BeginSend(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallBack), ClientSocket);
        }
        public void SendTo(string message, string to)
        {
            if (Encoding.UTF8.GetBytes(message).Length < BufferSize)
            {
                List<object> list = new List<object>();
                IMessagePackage Message = new MessagePackage(message, UserInformation.Name, to);
                list.Add(Message);
                Send(CastingHelper.ObjectListToByteArray(list));
            }
            else
            {
                Log.Add(new LogPackage("Maximum send limit has been exeeded. Please reduce the size before attempting to proceed. There is a maximum limit of " + (BufferSize / 1000000) + " mb."));
                OnLogUpdated();
            }
        }
        public void SendFile(Image image)
        {
            if (CastingHelper.Imagesize(image) < BufferSize)
            {
                IMediaPackage file = new MediaPackage(image);
                List<object> list = new List<object>();
                list.Add(file);
                Send(CastingHelper.ObjectListToByteArray(list));
            }
            else
            {
                Log.Add(new LogPackage("Maximum send limit has been exeeded. Please reduce the size before attempting to proceed. There is a maximum limit of " + (BufferSize / 1000000) + " mb."));
                OnLogUpdated();
            }
        }
        public void SendFileTo(Image image, string to)
        {
            if (CastingHelper.Imagesize(image) < BufferSize)
            {
                IMediaPackage file = new MediaPackage(image);
                List<object> list = new List<object>();
                list.Add(file);
                Send(CastingHelper.ObjectListToByteArray(list));
            }
            else
            {
                Log.Add(new LogPackage("Maximum send limit has been exeeded. Please reduce the size before attempting to proceed. There is a maximum limit of " + (BufferSize / 1000000) + " mb."));
                OnLogUpdated();
            }
        }
        public void Broadcast(string message)
        {
            List<object> list = new List<object>();
            IBroadCastPackage Broadcast = new BroadCastPackage(message, UserInformation.Name);
            list.Add(Broadcast);
            Send(CastingHelper.ObjectListToByteArray(list));
        }
        #endregion
        #region Data handling methods
        public void HandleUser(byte[] data)
        {
            IUserPackage User = Package.FromByteArray(data) as IUserPackage;
            if (!Users.Any(u => u.Email == User.Email))
            {
                Users.Add(User);
            }
            OnClientConnected();
        }
        public void HandleRequest(byte[] data)
        {
            try
            {
                RequestPackage serverRequest = Package.FromByteArray(data) as RequestPackage;
                if (serverRequest.Type == RequestPackage.RequestTypes.Get)
                {
                    if (serverRequest.Method == RequestPackage.RequestMethods.UpdateClients)
                    {
                        List<object> objectData = CastingHelper.ByteArrayToObjectList(serverRequest.Data);
                        foreach (object ob in objectData)
                        {
                            Users.Add(ob as IUserPackage);
                        }
                        OnClientConnected();
                    }
                }
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | HandleRequest | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        public void HandleNotification(byte[] data)
        {
            try
            {
                INotificationPackage noti = Package.FromByteArray(data) as INotificationPackage;
                ILogPackage log = new LogPackage(noti.Message);
                Log.Add(log);
                OnLogUpdated();
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | HandleNotification | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        public void ReceiveMessage(byte[] data)
        {
            try
            {
                IMessagePackage Message = Package.FromByteArray(data) as IMessagePackage;
                Messages.Add(Message);
                MessagesAllInOne.Add(Message);
                OnReceived();
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | ReceiveMessage | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        public void ReceiveBroadCast(byte[] data)
        {
            IBroadCastPackage Broadcast = Package.FromByteArray(data) as IBroadCastPackage;
            Broadcast.Delivered = DateTime.UtcNow;
            BroadcastMessages.Add(Broadcast);
            MessagesAllInOne.Add(Broadcast);
            OnReceived();
        }
        public void HandleLogUpdate(byte[] data)
        {
            try
            {
                ILogPackage log = Package.FromByteArray(data) as ILogPackage;
                Log.Add(log);
                OnLogUpdated();
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | HandleLogUpdate | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        public void HandleError(byte[] data)
        {
            try
            {
                IErrorPackage error = Package.FromByteArray(data) as IErrorPackage;
                Log.Add(new LogPackage(error.Message));
                OnLogUpdated();
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | HandleError | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        public void HandleFile(byte[] data)
        {
            IMediaPackage Media = Package.FromByteArray(data) as IMediaPackage;
            Files.Add(Media);
            MessagesAllInOne.Add(Media);
            OnReceived();
        }
        #endregion
        #region CallBacks
        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                Socket Client = (Socket)ar.AsyncState;
                if (Client.Connected)
                {
                    ClientSocket = Client;
                    OnConnected();
                    List<object> Requests = new List<object>();
                    List<object> users = new List<object>();
                    // Add each user in local users list to send to server.
                    foreach (IUserPackage User in Users) { users.Add(User); }
                    // Create Connect request
                    IRequestPackage Request = new RequestPackage(RequestPackage.RequestTypes.Get, UserInformation.ToByteArray(), RequestPackage.RequestMethods.Connect);
                    // Create Update client request
                    IRequestPackage Request2 = new RequestPackage(RequestPackage.RequestTypes.Get, CastingHelper.ObjectListToByteArray(users), RequestPackage.RequestMethods.UpdateClients);
                    Requests.Add(Request); Requests.Add(Request2);
                    byte[] data = CastingHelper.ObjectListToByteArray(Requests);
                    Send(data);
                    _Buffer = new byte[BufferSize];
                    ClientSocket.BeginReceive(_Buffer, 0, _Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), ClientSocket);
                }
            }
            catch (SocketException er)
            {
                Log.Add(new LogPackage("Client | ConnectCallBack | Socket Exception: " + er.Message + " Code: " + er.NativeErrorCode));
                OnLogUpdated();
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | ConnectCallBack | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = null;
                if (ar.AsyncState != null)
                {
                    socket = (Socket)ar.AsyncState;
                }
                else
                {
                    socket = ClientSocket;
                }
                int amount = socket.EndReceive(ar);
                byte[] receievedData = new byte[amount];
                Array.Copy(_Buffer, receievedData, receievedData.Length);

                IPacketHandler handler = new PacketHandler(receievedData);
                List<IPackageEntry> Entries = handler.HandleReceive();
                foreach (IPackageEntry Entry in Entries)
                {
                    switch (Entry.Type)
                    {
                        case (int)PacketHandler.PackageType.User: HandleUser(Entry.Data); break;
                        case (int)PacketHandler.PackageType.Request: HandleRequest(Entry.Data); break;
                        case (int)PacketHandler.PackageType.Notification: HandleNotification(Entry.Data); break;
                        case (int)PacketHandler.PackageType.Message: ReceiveMessage(Entry.Data); break;
                        case (int)PacketHandler.PackageType.Log: HandleLogUpdate(Entry.Data); break;
                        case (int)PacketHandler.PackageType.Error: HandleError(Entry.Data); break;
                        case (int)PacketHandler.PackageType.BroadCast: ReceiveBroadCast(Entry.Data); break;
                        case (int)PacketHandler.PackageType.File: HandleFile(Entry.Data); break;
                        default: IErrorPackage error = new ErrorPackage("Invalid request type.", 400); HandleError(error.ToByteArray()); break;
                    }
                }
                _Buffer = new byte[BufferSize];
                socket.BeginReceive(_Buffer, 0, _Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);
            }
            catch (SocketException er)
            {
                Log.Add(new LogPackage("Client | ReceiveCallBack | Socket Exception: " + er.Message + " Code: " + er.NativeErrorCode));
                OnLogUpdated();
            }
            catch (Exception er)
            {
                Log.Add(new LogPackage("Client | ReceiveCallBack | General Exception: " + er.Message));
                OnLogUpdated();
            }
        }
        private void SendCallBack(IAsyncResult ar)
        {
            Socket client = null;
            if (ar.AsyncState == null)
            {
                client = ClientSocket;
            }
            else
            {
                client = (Socket)ar.AsyncState;
            }
            int amount = client.EndSend(ar);
            Log.Add(new LogPackage("Sent " + amount + " bytes."));
            OnLogUpdated();
        }
        #endregion
    }
}