namespace Client.Services
{
    public class ActivityPlanService : ServiceBase
    {
        public ActivityPlanService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "ActivityPlans";
        }

        public ViewModels.ActivityPlanViewModel MyActivityPlan { get; set; } 
            = new ViewModels.ActivityPlanViewModel();

        public async Task<IList<Models.ActivityPlan>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.ActivityPlan>>();

            return result;
        }

        public async Task<IList<ViewModels.ActivityPlanIndexViewModel>> GetIndexByPlanIdAsync(string planId)
        {
            var query = $"ActivityPlanIndexByPlanId/{planId}";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ActivityPlanIndexViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.ActivityPlanViewModel> GetByPlanIdAsync(string planId)
        {
            var query = $"ActivityPlanByPlanId/{planId}";
            var result =
                await ServiceBaseGetAsync<ViewModels.ActivityPlanViewModel>(query: query);

            return result;
        }

        public async Task<ViewModels.ActivityPlanViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.ActivityPlanViewModel>(query: query);

            return result;
        }

        public async Task<ViewModels.ActivityPlanTitelViewModel> GetActivityPlanTitelbyId(string id)
        {
            var query = $"Titel/{id}";

            var result =
                await ServiceBaseGetAsync<ViewModels.ActivityPlanTitelViewModel>(query: query);

            return result;
        }

        public async Task<ViewModels.ActivityPlanSummaryViewModel> GetSummaryAsync(string id)
        {
            var query = $"Summary/{id}";

            var result =
                await ServiceBaseGetAsync<ViewModels.ActivityPlanSummaryViewModel>(query: query);

            return result;
        }

        public async Task<ViewModels.ActivityPlanViewModel> PostAsync(ViewModels.ActivityPlanViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.ActivityPlanViewModel, ViewModels.ActivityPlanViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.ActivityPlanViewModel> PutAsync(ViewModels.ActivityPlanViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.ActivityPlanViewModel, ViewModels.ActivityPlanViewModel>(entity);

            return result;
        }

        public async Task<bool> DeleteAsync(string? query = null)
        {
            bool result =
                await ServiceBaseDeleteAsync<bool>(query);

            return result;
        }
    }
}
