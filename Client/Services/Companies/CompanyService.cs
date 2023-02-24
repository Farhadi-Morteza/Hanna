namespace Client.Services
{
    public class CompanyService : ServiceBase
    {
        public CompanyService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Companies";
        }

        public async Task<IList<Models.Company>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.Company>>();

            return result;
        }

        public async Task<IList<ViewModels.CompanySelectViewModel>> GetSelectAsync(Data.Tools.Enums.CompanyCategories companyCategories)
        {
            string query = $"Select {companyCategories}";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.CompanySelectViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.CompanyViewModel> GetByIdAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.CompanyViewModel>(query: query);

            return result;
        }

        public async Task<Models.Company> PostAsync(ViewModels.CompanyViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.CompanyViewModel, Models.Company>(entity);

            return result;
        }

        public async Task<Models.Company> PutAsync(ViewModels.CompanyViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.CompanyViewModel, Models.Company>(entity);

            return result;
        }

        public async Task<bool> DeleteAsync(string query = null)
        {
            var result =
                await ServiceBaseDeleteAsync<Models.Company>(query);

            return result;
        }
    }
}
