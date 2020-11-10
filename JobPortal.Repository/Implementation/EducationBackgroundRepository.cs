using System.Data.Entity;
using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class EducationBackgroundRepository : Repository<EducationBackground>, IEducationBackgroundRepository
    {
        public EducationBackgroundRepository(System.Data.Entity.DbContext ctx) : base(ctx)
        {

        }
    }
}
