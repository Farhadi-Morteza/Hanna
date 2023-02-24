

namespace Data.Products
{
    public interface IActivityIndicatorRepository : IRepositoryBase<Models.ActivityIndicator>
    {
        Task<List<ViewModels.ActivityIndicatorViewModel>> GetIndexAsync();
        Task<ViewModels.ActivityIndicatorViewModel> GetIndexByIdAsync(Guid id);
        Task<List<ViewModels.ActivityIndicatorSelectViewModel>> GetSelectAsync();
    }
}
