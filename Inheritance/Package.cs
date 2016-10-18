using GlobalDevelopment.Helpers;
using GlobalDevelopment.Interfaces;
using System;

namespace GlobalDevelopment.Inheritance
{
    [Serializable]
    public class Package : IPackage
    {
        #region Properties
        public enum Priorities
        {
            Request = 1,
            User = 2,
            Notification = 3,
            Broadcast = 4,
            Message = 5,
            Log = 6,
            Error = 7,
            File = 8
        }
        public Guid ID { get; set; }
        public Priorities Priority { get; set; }
        #endregion
        #region Constructors
        public Package(Guid id, Priorities priority)
        {
            ID = id;
            Priority = priority;
        }
        #endregion
        #region Methods
        public static IPackage FromByteArray(byte[] data)
        {
            return CastingHelper.ByteArrayToObject(data) as IPackage;
        }
        public byte[] ToByteArray()
        {
            return CastingHelper.ObjectToByteArray(this);
        }
        #endregion
    }
}