using JobPortal.Models.Implementation;
using JobPortal.Models.ViewModels;

namespace JobPortal.Services.Contract
{
    public interface IResumeService
    {
        JobSeeker SaveNewResume(User user, EditResumeViewModel model);
        void UpdateExistingResume(JobSeeker theResume, EditResumeViewModel model);
        //IDictionary<string, string> SaveImageToFolder(HttpPostedFileBase file, string serverPath, string defaultImgPath);
    }
}
