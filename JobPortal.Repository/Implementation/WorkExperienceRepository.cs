using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;
using System.Data.Entity;

namespace JobPortal.Repository.Implementation
{
    public class WorkExperienceRepository : Repository<WorkExperience>, IWorkExperienceRepository
    {
        public WorkExperienceRepository(System.Data.Entity.DbContext ctx) : base(ctx)
        {

        }
    }
}
