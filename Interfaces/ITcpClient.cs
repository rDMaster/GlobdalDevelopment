using System.Collections.Generic;
using System.Drawing;

namespace GlobalDevelopment.Interfaces
{
    public interface ITcpClient : IClient
    {
        #region Properties
        int BufferSize { get; set; }
        IUserPackage UserInformation { get; set; }
        List<IUserPackage> Users { get; set; }
        List<IMediaPackage> Files { get; set; }
        #endregion
        #region Methods
        void Connect();
        void Disconnect(bool reuse);
        void Send(byte[] data);
        void SendTo(string message, string to);
        void SendFile(Image image);
        void SendFileTo(Image image, string to);
        void Broadcast(string message);
        #endregion
        #region Data handling methods
        void HandleUser(byte[] data);
        void HandleRequest(byte[] data);
        void HandleNotification(byte[] data);
        void ReceiveMessage(byte[] data);
        void ReceiveBroadCast(byte[] data);
        void HandleLogUpdate(byte[] data);
        void HandleError(byte[] data);
        void HandleFile(byte[] data);
        #endregion
    }
}