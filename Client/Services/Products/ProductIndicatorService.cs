namespace Client.Services
{
    public class ProductIndicatorService : ServiceBase
    {
        public ProductIndicatorService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "ProductIndicator";
        }

        public async Task<IList<ViewModels.ProductIndicatorViewModel>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ProductIndicatorViewModel>>();

            return result;
        }

        public async Task<ViewModels.ProductIndicatorViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.ProductIndicatorViewModel>(query: query);

            return result;
        }

        public async Task<IList<ViewModels.ProductIndicatorSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ProductIndicatorSelectViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.ProductIndicatorViewModel> PostAsync(ViewModels.ProductIndicatorViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.ProductIndicatorViewModel, ViewModels.ProductIndicatorViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.ProductIndicatorViewModel> PutAsync(ViewModels.ProductIndicatorViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.ProductIndicatorViewModel, ViewModels.ProductIndicatorViewModel>(entity);

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
