namespace Client.Services
{
    public class ProductActivityPlanService : ServiceBase
    {
        public ProductActivityPlanService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "productActivityPlans";
        }

        public async Task<IList<Models.ProductActivityPlan>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.ProductActivityPlan>>();

            return result;
        }

        public async Task<IList<Models.ProductActivityPlan>> GetIndexByActivityPlanId(string activityPlanId)
        {
            var query = $"ProductActivityPlanIndexByActivityPlanId/{activityPlanId}";
            var result = 
                await ServiceBaseGetAsync<IList<Models.ProductActivityPlan>>(query);

            return result;
        }

        public async Task<ViewModels.ProductActivityPlanViewModel> GetByActivityPlanIdAsync(string activityPlanId)
        {
            var query = $"ProductActivityPlanByActivityPlanId/{activityPlanId}";
            var result =
                await ServiceBaseGetAsync<ViewModels.ProductActivityPlanViewModel>(query);

            return result;
        }

        public async Task<ViewModels.ProductActivityPlanViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.ProductActivityPlanViewModel>(query: query);

            return result;
        }

        public async Task<ViewModels.ProductActivityPlanViewModel> PostAsync(ViewModels.ProductActivityPlanViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.ProductActivityPlanViewModel, ViewModels.ProductActivityPlanViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.ProductActivityPlanViewModel> PutAsync(ViewModels.ProductActivityPlanViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.ProductActivityPlanViewModel, ViewModels.ProductActivityPlanViewModel>(entity);

            return result;
        }

        public async Task<bool> DeleteAsync(string query = null)
        {
            var result =
                await ServiceBaseDeleteAsync<ViewModels.ProductActivityPlanViewModel>(query);

            return result;
        }
    }
}
