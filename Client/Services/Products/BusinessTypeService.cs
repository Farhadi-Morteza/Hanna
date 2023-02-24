namespace Client.Services
{
    public class BusinessTypeService : ServiceBase
    {
        public BusinessTypeService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "BusinessType";
        }

        public async Task<IList<Models.BusinessType>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.BusinessType>>();

            return result;
        }

        public async Task<ViewModels.BusinessTypeViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.BusinessTypeViewModel>(query: query);

            return result;
        }

        public async Task<IList<ViewModels.BusinessTypeSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.BusinessTypeSelectViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.BusinessTypeViewModel> PostAsync(ViewModels.BusinessTypeViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.BusinessTypeViewModel, ViewModels.BusinessTypeViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.BusinessTypeViewModel> PutAsync(ViewModels.BusinessTypeViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.BusinessTypeViewModel, ViewModels.BusinessTypeViewModel>(entity);

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
