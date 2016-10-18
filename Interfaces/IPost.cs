using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IPost
    {
        string postMessage { get; set; }
        string ImageSrc { get; set; }
        string PostUrl { get; set; }
        string CreatedDate { get; set; }
        string OwnerName { get; set; }
    }
}
