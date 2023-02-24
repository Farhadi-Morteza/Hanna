namespace Client.Services
{
    public class ActivityIndicatorService : ServiceBase
    {
        public ActivityIndicatorService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "ActivityIndicator";
        }

        public async Task<IList<ViewModels.ActivityIndicatorViewModel>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ActivityIndicatorViewModel>>();

            return result;
        }

        public async Task<ViewModels.ActivityIndicatorViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.ActivityIndicatorViewModel>(query: query);

            return result;
        }

        public async Task<IList<ViewModels.ActivityIndicatorSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ActivityIndicatorSelectViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.ActivityIndicatorViewModel> PostAsync(ViewModels.ActivityIndicatorViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.ActivityIndicatorViewModel, ViewModels.ActivityIndicatorViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.ActivityIndicatorViewModel> PutAsync(ViewModels.ActivityIndicatorViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.ActivityIndicatorViewModel, ViewModels.ActivityIndicatorViewModel>(entity);

            return result;
        }

        public async Task<bool> DeleteAsync(string query = null)
        {
            var result =
                await ServiceBaseDeleteAsync<bool>(query);

            return result;
        }
    }
}
