using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {

        }
    }
}
