namespace Client.Services
{
    public class CompanyCategoryService : ServiceBase
    {
        public CompanyCategoryService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "CompanyCategory";
        }

        public async Task<IList<Models.CompanyCategory>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.CompanyCategory>>();

            return result;
        }

        public async Task<Models.CompanyCategory> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<Models.CompanyCategory>(query: query);

            return result;
        }

        public async Task<Models.CompanyCategory> PostAsync(Models.CompanyCategory entity)
        {
            var result =
                await ServiceBasePostAsync<Models.CompanyCategory, Models.CompanyCategory>(entity);

            return result;
        }

        public async Task<Models.CompanyCategory> PutAsync(Models.CompanyCategory entity)
        {
            var result =
                await ServiceBasePutAsync<Models.CompanyCategory, Models.CompanyCategory>(entity);

            return result;
        }

        public async Task<bool> DeleteAsync(string query = null)
        {
            var result =
                await ServiceBaseDeleteAsync<Models.CompanyCategory>(query);

            return result;
        }
    }
}
