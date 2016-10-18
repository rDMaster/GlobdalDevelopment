using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Interfaces
{
    public interface IFacebookCover
    {
        string PhotoID { get; set; }
        string CoverID { get; set; }
        string OffsetX { get; set; }
        string OffsetY { get; set; }
        string SourceUrl { get; set; }
    }
}
