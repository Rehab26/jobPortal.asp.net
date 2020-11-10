using JobPortal.Models.Implementation;
using System.Collections.Generic;

namespace JobPortal.Repository.Contract
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        List<User> GetApplicants(long jobId);
    }
}
