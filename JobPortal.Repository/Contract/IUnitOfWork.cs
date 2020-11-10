using System;

namespace JobPortal.Repository.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository companyRepository { get; set; }
        IJobRepository jobRepository { get; set; }
        IJobCategoryRepository jobCategoryRepository { get; set; }

        IJobApplicationRepository jobApplicationRepository { get; set; }
        IWorkExperienceRepository workExperienceRepository { get; set; }
        IEducationBackgroundRepository educationBackgroundRepository { get; set; }
        IResumeRepository resumeRepository { get; set; }
        IUserRepository userRepository { get; set; }
        ILanguageRepository languageRepository { get; set; }

        void Save();
    }
}
