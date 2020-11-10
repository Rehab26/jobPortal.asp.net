using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {
        }
        public List<User> GetApplicants(long jobId)
        {
            return this.Find(j => j.job.ID == jobId).ToList().Select(j => j.User).ToList();
        }
    }
}
