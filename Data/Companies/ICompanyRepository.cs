
using Models;
using ViewModels;

namespace Data.Companies
{
    public interface ICompanyRepository : IRepositoryBase<Models.Company>
    {
        Task<List<Company>> GetIndexAsync();
        Task<List<Company>> GetRecursiveAsync(Guid id);
        Task<List<CompanySelectViewModel>> GetSelectAsync(Tools.Enums.CompanyCategories? companyCategories);
    }
}
