using System.Collections.Generic;
using System.Web;

namespace JobPortal.Services.Contract
{
    public interface IUtilityService
    {
        IDictionary<string, string> SaveImageToFolder(HttpPostedFileBase file, string serverPath, string defaultImgPath);
    }
}
