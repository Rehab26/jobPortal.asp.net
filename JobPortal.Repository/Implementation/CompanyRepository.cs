using System.Linq;
using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(System.Data.Entity.DbContext dbContext) : base(dbContext)
        {

        }
        public Company GetCompanyByUserId(string userId)
        {
            return base.Find(c => string.Compare(c.UserId, userId, true) == 0).FirstOrDefault();
        }
    }
}
