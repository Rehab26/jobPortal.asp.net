using JobPortal.Services.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JobPortal.Services.Implementation
{
    public class UtilityService : IUtilityService
    {
        public IDictionary<string, string> SaveImageToFolder(HttpPostedFileBase file, string serverPath, string defaultImgPath)
        {
            if (file == null || file.ContentLength < 1)
            {
                return new Dictionary<string, string> { { "status", "error" }, { "msg", defaultImgPath } };   //Json(new { status = "error", msg = Server.MapPath("~/assets/images/user.jpg") });
            }

            var imageString = file.ToString();
            var allowedExtensions = new[]
            {
                ".jpg", ".png", ".jpg", ".jpeg"
            };

            var fileName = Path.GetFileName(file.FileName); //eg myImage.jpg
            var extension = Path.GetExtension(file.FileName);    //eg .jpg

            if (allowedExtensions.Contains(extension.ToLower()))
            {
                string ordinaryFileName = Path.GetFileNameWithoutExtension(file.FileName);
                string myFile = ordinaryFileName + "_" + Guid.NewGuid() + extension;
                var path = Path.Combine(serverPath, myFile);
                file.SaveAs(path);

                string relativePath = "~/assets/images/UserProfileImages/" + myFile;
                return new Dictionary<string, string> { { "status", "success" }, { "msg", relativePath } };
            }
            else
            {
                return new Dictionary<string, string> { { "status", "error" }, { "msg", "media not supported!" } };
            }
        }
    }
}
