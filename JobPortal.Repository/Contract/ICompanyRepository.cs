using JobPortal.Models.Implementation;

namespace JobPortal.Repository.Contract
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetCompanyByUserId(string userId);
    }
}
