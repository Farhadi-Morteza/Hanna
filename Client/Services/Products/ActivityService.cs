namespace Client.Services
{
    public class ActivityService : ServiceBase
    {
        public ActivityService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Activity";
        }

        public async Task<IList<Models.Activity>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.Activity>>();

            return result;
        }

        public async Task<ViewModels.ActivityViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.ActivityViewModel>(query: query);

            return result;
        }

        public async Task<IList<ViewModels.ActivitySelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ActivitySelectViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.ActivityViewModel> PostAsync(ViewModels.ActivityViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.ActivityViewModel, ViewModels.ActivityViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.ActivityViewModel> PutAsync(ViewModels.ActivityViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.ActivityViewModel, ViewModels.ActivityViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.ActivityViewModel> PostActivityProductAsync(ViewModels.ActivityProductViewModel entity)
        {
            string query = "ActivityProduct";

            var result =
                await ServiceBasePostAsync<ViewModels.ActivityProductViewModel, ViewModels.ActivityViewModel>(entity, query);

            return result;
        }

        public async Task<bool> DeleteAsync(string query = null)
        {
            var result =
                await ServiceBaseDeleteAsync<ViewModels.ActivityViewModel>(query);

            return result;
        }

        public async Task<ViewModels.ActivityViewModel> DeleteActivityProductAsync(ViewModels.ActivityProductViewModel entity)
        {
            string query = "DeleteActivityProduct";

            var result =
                await ServiceBasePostAsync<ViewModels.ActivityProductViewModel, ViewModels.ActivityViewModel>(entity, query);

            return result;

        }
    }
}
