using System.IO;
using System.Web;
using Umbraco.Web.Mvc;

namespace GlobalDevelopment.Controllers
{
    public class SystemSurfaceController : SurfaceController
    {
        // Create Folder | Properties: 2 | String : FolderName, String : Url
        public string CreateFolder(string FolderName)
        {
            string result = "Failed!";
            if (FolderName != "" && FolderName != null)
            {
                var path = Path.GetFullPath(Server.MapPath(VirtualPathUtility.ToAppRelative("~")));
                if (!Directory.Exists(path + "/" + FolderName))
                {
                    Directory.CreateDirectory(path + "/" + FolderName);
                    result = "SUCCESS!";
                }
                else
                {
                    result = "Folder already exists";
                }
            }
            return result;
        }
    }
}