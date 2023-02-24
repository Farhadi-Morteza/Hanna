namespace Client.Services
{
    public class YearService : ServiceBase
    {
        public YearService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Years";
        }

        public async Task<IList<Models.Year>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.Year>>();

            return result;
        }

        public async Task<Models.Year> GetByIdAsync(string? query = null)
        {
            var result =
                await ServiceBaseGetAsync<Models.Year>(query);

            return result;
        }

        public async Task<IList<ViewModels.YearSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.YearSelectViewModel>>(query: query);

            return result;
        }

        public async Task<Models.Year> PostAsync(ViewModels.YearSelectViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.YearSelectViewModel, Models.Year>(entity);

            return result;
        }

        public async Task<Models.Year> PutAsync(Models.Year entity)
        {
            var result =
                await ServiceBasePutAsync<Models.Year, Models.Year>(entity);

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
