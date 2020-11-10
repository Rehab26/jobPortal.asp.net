using System;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private System.Data.Entity.DbContext context;// = new DbContext();

        //ICompanyRepository gcompanyRepository;   
        public UnitOfWork(System.Data.Entity.DbContext _context, ICompanyRepository _companyRepository , IJobCategoryRepository _jobCategoryRepository
            , IJobRepository _jobRepository,
            IJobApplicationRepository _jobApplicationRepository, IWorkExperienceRepository _workExperienceRepository,
            IEducationBackgroundRepository _educationBackgroundRepository, IResumeRepository _resumeRepository,
            IUserRepository _userRepository, ILanguageRepository _languageRepo)
        {
            companyRepository = _companyRepository;
            jobRepository = _jobRepository;
            jobCategoryRepository = _jobCategoryRepository;
            jobApplicationRepository = _jobApplicationRepository;
            workExperienceRepository = _workExperienceRepository;
            educationBackgroundRepository = _educationBackgroundRepository;
            resumeRepository = _resumeRepository;
            userRepository = _userRepository;
            languageRepository = _languageRepo;

            context = _context;
        }



        public ICompanyRepository companyRepository
        {
            get;
            set;
        }

        public IJobRepository jobRepository
        {
            get;
            set;
        }

        
        public IJobApplicationRepository jobApplicationRepository { get; set; }
        public IWorkExperienceRepository workExperienceRepository { get; set; }
        public IEducationBackgroundRepository educationBackgroundRepository { get; set; }
        public IResumeRepository resumeRepository { get; set; }
        public IUserRepository userRepository { get; set; }
        public ILanguageRepository languageRepository { get; set; }
        public IJobCategoryRepository jobCategoryRepository
        {
            get;
            set;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
