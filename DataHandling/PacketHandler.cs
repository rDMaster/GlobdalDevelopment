using GlobalDevelopment.Helpers;
using GlobalDevelopment.Interfaces;
using GlobalDevelopment.Models;
using GlobalDevelopment.Packages;
using System.Collections.Generic;
using System.Linq;

namespace GlobalDevelopment.Packets
{
    public class PacketHandler : IPacketHandler
    {
        #region Properties
        public List<object> Packages { get; set; }
        public List<int> Types { get; set; }
        public PacketHandler(byte[] data)
        {
            Packages = CastingHelper.ByteArrayToObjectList(data);
            Types = new List<int>();
        }
        #endregion
        #region Enums
        public enum Errors
        {
            Success = 0,
            OperationNotPermitted = 1,
            NoSuchFileOrDirectory = 2,
            NoSuchProccess = 3,
            InterruptedSystemCall = 4,
            InputOutputError = 5,
            NoSuchDeviceOrAddress = 6,
            ArgumentListTooLong = 7,
            ExecFormatError = 8,
            NotFound = 404,
            BadRequest = 400
        }
        public enum PackageType
        {
            Request = 1000,
            User = 1001,
            Log = 1002,
            Message = 1003,
            Notification = 1004,
            Error = 1005,
            BroadCast = 1006,
            File = 1007
        }
        #endregion
        #region Methods
        public byte[] HandleSend()
        {
            return CastingHelper.ObjectListToByteArray(Packages);
        }
        public List<IPackageEntry> HandleReceive()
        {
            List<IPackageEntry> list = new List<IPackageEntry>();

            foreach (object package in Packages)
            {
                IUserPackage userPackage = package as IUserPackage;
                ILogPackage logPackage = package as ILogPackage;
                IMessagePackage messagePackage = package as IMessagePackage;
                IRequestPackage requestPackage = package as IRequestPackage;
                IBroadCastPackage broadcastPackage = package as IBroadCastPackage;
                INotificationPackage notificationPackage = package as INotificationPackage;
                IErrorPackage errorPackage = package as IErrorPackage;

                IPackageEntry entry;

                if (requestPackage != null) { entry = new PackageEntry((int)PackageType.Request, requestPackage.ToByteArray(), requestPackage.ID); }
                else if (userPackage != null) { entry = new PackageEntry((int)PackageType.User, userPackage.ToByteArray(), userPackage.ID); }
                else if (logPackage != null) { entry = new PackageEntry((int)PackageType.Log, logPackage.ToByteArray(), logPackage.ID); }
                else if (messagePackage != null) { entry = new PackageEntry((int)PackageType.Message, messagePackage.ToByteArray(), messagePackage.ID); }
                else if (broadcastPackage != null) { entry = new PackageEntry((int)PackageType.BroadCast, broadcastPackage.ToByteArray(), broadcastPackage.ID); }
                else if (notificationPackage != null) { entry = new PackageEntry((int)PackageType.Notification, notificationPackage.ToByteArray(), notificationPackage.ID); }
                else if (errorPackage != null) { entry = new PackageEntry((int)PackageType.Error, errorPackage.ToByteArray(), errorPackage.ID); }
                else { IErrorPackage error = new ErrorPackage("Invalid Package Type.", (int)Errors.NotFound); entry = new PackageEntry((int)PackageType.Error, error.ToByteArray(), error.ID); }
                list.Add(entry);
            }
            return list.OrderBy(p => p.priority).ToList();
        }
        #endregion
    }
}