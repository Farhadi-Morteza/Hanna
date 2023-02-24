namespace Client.Services
{
    public class PlanService : ServiceBase
    {
        public PlanService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Plans";
        }

        public ViewModels.PlanViewModel Myplan { get; set; } = new ViewModels.PlanViewModel();

        public async Task<IList<ViewModels.PlanViewModel>> GetAsync(string? query = null)
        {
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.PlanViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.PlanViewModel> GetByIdAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.PlanViewModel>(query: query);

            return result;
        }

        public async Task<ViewModels.PlanTitelViewModel> GetPlanTitelByIdAsync(string id)
        {
            var query = $"Titel/{id}";

            var result =
                await ServiceBaseGetAsync < ViewModels.PlanTitelViewModel>(query: query);

            return result;
        }

        public async Task<Models.Plan> GetPlanActivityIndexAsync(string id = null)
        {
            string query = $"PlanActiviyIndex/{id}";
            var result =
                await ServiceBaseGetAsync<Models.Plan>(query: query);

            return result;
        }

        public async Task<ViewModels.PlanViewModel> PostAsync(ViewModels.PlanViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.PlanViewModel, ViewModels.PlanViewModel>(entity);

            return result;
        }

        public async Task<bool> PostAllAsync(bool nextYear = false, bool thisYear = false)
        {
            string query = $"All?nextYear={nextYear}&thisYear={thisYear}";
            var result =
                await ServiceBasePostAsync<bool, bool>(false, query: query);

          

            return result;
        }

        public async Task<ViewModels.PlanViewModel> PutAsync(ViewModels.PlanViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.PlanViewModel, ViewModels.PlanViewModel>(entity);

            return result;
        }

        public async Task<bool> PlanCheckoutAsync(string id)
        {
            string query = $"PlanCheckout/{id}";
            var result =
                await ServiceBasePutAsync<string, bool>(id, query: query);

            return result;
        }

        public async Task<bool> RejectPlanCheckoutAsync(string id)
        {
            string query = $"RejectPlanCheckout/{id}";
            var result =
                await ServiceBasePutAsync<string, bool>(id, query: query);

            return result;
        }

        public async Task<bool> PlanApprovalAsync(string id)
        {
            string query = $"PlanApproval/{id}";
            var result =
                await ServiceBasePutAsync<string, bool>(id, query: query);

            return result;
        }

        public async Task<bool> RejectPlanApprovalAsync(string id)
        {
            string query = $"RejectPlanApproval/{id}";
            var result =
                await ServiceBasePutAsync<string, bool>(id, query: query);

            return result;
        }

        public async Task<bool> DeleteAsync(string query = null)
        {
            var result =
                await ServiceBaseDeleteAsync<ViewModels.PlanViewModel>(query);

            return result;
        }

    }
}
