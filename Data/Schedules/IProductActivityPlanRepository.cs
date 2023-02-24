
using Models;
using ViewModels;

namespace Data.Schedules
{
    public interface IProductActivityPlanRepository : IRepositoryBase<Models.ProductActivityPlan>
    {
        Task<ProductActivityPlanViewModel> GetProductActivityPlanByActivityPlanIdAsync(Guid activityPlanId);
        Task<ProductActivityPlanViewModel> GetProductActivityPlanByIdAsync(Guid id);
        Task<List<ProductActivityPlan>> GetProductActivityPlanIndexByActivityPlanIdAsync(Guid activityPlanId);
    }
}
