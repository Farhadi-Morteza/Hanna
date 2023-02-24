namespace Client.Services
{
    public class MetricService : ServiceBase
    {
        public MetricService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Metric";
        }

        public async Task<IList<Models.Metric>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.Metric>>();

            return result;
        }

        public async Task<ViewModels.MetricViewModel> GetByIdAsync(string? query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.MetricViewModel>(query);

            return result;
        }

        public async Task<IList<ViewModels.MetricSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.MetricSelectViewModel>>(query: query);

            return result;
        }

        public async Task<Models.Metric> PostAsync(ViewModels.MetricViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.MetricViewModel, Models.Metric>(entity);

            return result;
        }

        public async Task<Models.Metric> PutAsync(ViewModels.MetricViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.MetricViewModel, Models.Metric>(entity);

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
