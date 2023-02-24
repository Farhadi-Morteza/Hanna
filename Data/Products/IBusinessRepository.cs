
namespace Data.Products
{
    public interface IBusinessRepository : IRepositoryBase<Models.Business>
    {
        Task<List<ViewModels.BusinessViewModel>> GetIndexAsync();
        Task<ViewModels.BusinessViewModel> GetIndexByIdAsync(Guid id);
        Task<List<ViewModels.BusinessSelectViewModel>> GetSelectAsync();
    }
}
