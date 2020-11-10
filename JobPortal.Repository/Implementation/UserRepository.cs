using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(System.Data.Entity.DbContext ctx) : base(ctx)
        {

        }
    }
}
