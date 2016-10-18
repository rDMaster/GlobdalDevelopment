using GlobalDevelopment.Interfaces;
using System;

namespace GlobalDevelopment.Models
{
    public class PackageEntry : IPackageEntry
    {
        public int Type { get; set; }
        public byte[] Data { get; set; }
        public Guid PackageId { get; set; }
        public int priority { get; set; }
        public PackageEntry(int type, byte[] data, Guid packageId)
        {
            Type = type; Data = data; PackageId = packageId;
        }
    }
}