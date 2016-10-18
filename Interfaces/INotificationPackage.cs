using System;

namespace GlobalDevelopment.Interfaces
{
    public interface INotificationPackage : IPackage
    {
        #region Properties
        string Message { get; set; }
        DateTime Sent { get; set; }
        DateTime Received { get; set; }
        #endregion
    }
}