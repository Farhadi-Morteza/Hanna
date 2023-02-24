
using Models;
using ViewModels;

namespace Data.Schedules
{
    public interface IActivityPlanRepository : IRepositoryBase<Models.ActivityPlan>
    {
        Task<ActivityPlanViewModel> GetActivityPlanByIdAsync(Guid id);
        Task<ActivityPlanViewModel> GetActivityPlanByPlanIdAsync(Guid planId);
        Task<List<ActivityPlanIndexViewModel>> GetActivityPlanIndexByPlanIdAsync(Guid planId);
        Task<ActivityPlanSummaryViewModel> GetActivityPlanSummaryAsync(Guid id);
        Task<ActivityPlanTitelViewModel> GetActivityPlanTitelById(Guid id);
    }
}
