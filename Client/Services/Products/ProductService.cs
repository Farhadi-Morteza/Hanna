namespace Client.Services
{
    public class ProductService : ServiceBase
    {
        public ProductService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Product";
        }

        public async Task<IList<ViewModels.ProductViewModel>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ProductViewModel>>();

            return result;
        }

        public async Task<ViewModels.ProductViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.ProductViewModel>(query: query);

            return result;
        }

        public async Task<IList<ViewModels.ProductViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ProductViewModel>>(query: query);

            return result;
        }

        public async Task<IList<ViewModels.ProductSelectViewModel>> GetSelectByActivityIdAsync(string activityId)
        {
            string query = $"SelectByActivityId/{activityId}";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ProductSelectViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.ProductViewModel> PostAsync(ViewModels.ProductViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.ProductViewModel, ViewModels.ProductViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.ProductViewModel> PutAsync(ViewModels.ProductViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.ProductViewModel, ViewModels.ProductViewModel>(entity);

            return result;
        }

        public async Task<bool> DeleteAsync(string query = null)
        {
            var result =
                await ServiceBaseDeleteAsync<ViewModels.ProductViewModel>(query);

            return result;
        }
    }
}
