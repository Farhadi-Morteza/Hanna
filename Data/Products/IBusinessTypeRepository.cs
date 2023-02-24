

using ViewModels;

namespace Data.Products
{
    public interface IBusinessTypeRepository : IRepositoryBase<Models.BusinessType>
    {
        Task<List<BusinessTypeSelectViewModel>> GetSelectAsync();
    }
}
