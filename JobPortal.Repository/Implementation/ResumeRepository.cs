using System.Data.Entity;
using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class ResumeRepository : Repository<JobSeeker>, IResumeRepository
    {
        public ResumeRepository(System.Data.Entity.DbContext ctx) : base(ctx)
        {

        }
    }
}
