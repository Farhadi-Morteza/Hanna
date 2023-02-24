namespace Client.Services
{
    public class BusinessService : ServiceBase
    {
        public BusinessService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Business";
        }

        public async Task<IList<ViewModels.BusinessViewModel>> GetAsync()
        {
            //var result =
            //    new List<Models.Business>();

            //await Task.Run(() =>
            //{
            //    for (int i = 0; i < 20; i++)
            //    {
            //        var entity = new Models.Business { Name = $"Business{i + 1 }", IsActive = true };
            //        result.Add(entity);
            //    }
            //});

            var result =
                await ServiceBaseGetAsync<IList<ViewModels.BusinessViewModel>>();

            return result;
        }

        public async Task<ViewModels.BusinessViewModel> GetAsync(string query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.BusinessViewModel>(query: query);

            return result;
        }

        public async Task<IList<ViewModels.BusinessSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.BusinessSelectViewModel>>(query: query);

            return result;
        }

        public async Task<ViewModels.BusinessViewModel> PostAsync(ViewModels.BusinessViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.BusinessViewModel, ViewModels.BusinessViewModel>(entity);

            return result;
        }

        public async Task<ViewModels.BusinessViewModel> PutAsync(ViewModels.BusinessViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.BusinessViewModel, ViewModels.BusinessViewModel>(entity);

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
