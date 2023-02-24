
using Models;
using ViewModels;

namespace Data.Schedules
{
    public interface IPlanRepository : IRepositoryBase<Models.Plan>
    {
        Task<PlanActivityViewModel> GetPlan_ActivityPlanByPlanIdAsync(Guid id);
        Task<PlanViewModel> GetIndexByIdAsync(Guid id);
        Task<bool> SavedLastTime(Guid companyId, Guid yearId);
        Task<Models.Plan> GetPlanActivityIndexByPlanIdAsync(Guid id);
        Task<List<PlanViewModel>> GetSuggestedPlanAsync();
        Task<List<PlanViewModel>> GetCheckoutPlanAsync();
        Task<PlanTitelViewModel> GetPlanTitelByIdAsync(Guid id);
    }
}
