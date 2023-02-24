
namespace Data.Products
{
    public interface IProductIndicatorRepository : IRepositoryBase<Models.ProductIndicator>
    {
        Task<List<ViewModels.ProductIndicatorViewModel>> GetIndexAsync();
        Task<ViewModels.ProductIndicatorViewModel> GetIndexByIdAsync(Guid id);
        Task<List<ViewModels.ProductIndicatorSelectViewModel>> GetSelectAsync();
    }
}
