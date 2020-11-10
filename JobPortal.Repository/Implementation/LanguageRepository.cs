using System.Data.Entity;
using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;

namespace JobPortal.Repository.Implementation
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(System.Data.Entity.DbContext ctx) : base(ctx)
        {

        }
    }
}
