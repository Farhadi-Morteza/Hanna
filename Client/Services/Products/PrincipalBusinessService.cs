namespace Client.Services
{
    public class PrincipalBusinessService : ServiceBase
    {
        public PrincipalBusinessService(HttpClient client) : base(client)
        {

        }

        protected override string GetApiUrl()
        {
            return "principalbusiness";
        }

        public async Task<IList<Models.PrincipalBusiness>> GetAsync()
        {
            //MOCK Data------------------------------------------------------------------------------
            //var result =
            //    new List<ViewModels.PrincipalBusiness.IndexVM>();
            //await Task
            //    .Run
            //    (
            //    () =>
            //    {
            //        for (int i = 0; i < 30; i++)
            //        {
            //            var entity =
            //                new ViewModels.PrincipalBusiness.IndexVM { Name = $"{Resources.DataDictionary.Name}{ i + 1}", IsActive = true };

            //            result.Add(entity);
            //        }

            //    }
            //    );
            //-------------------------------------------------------------------------------------------

            var result = 
                await ServiceBaseGetAsync<IList<Models.PrincipalBusiness>>();

            return result;
        }

        public async Task<ViewModels.PrincipalBusinessViewModel> GetByIdAsync(string? query = null)
        {
            var result =
                await ServiceBaseGetAsync<ViewModels.PrincipalBusinessViewModel>(query);

            return result;
        }

        public async Task<IList<Models.PrincipalBusiness>> GetActiveAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<Models.PrincipalBusiness>>("Active");

            return result;
        }

        public async Task<IList<ViewModels.PrincipalBusinessSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.PrincipalBusinessSelectViewModel>>(query: query);

            return result;
        }

        public async Task<Models.PrincipalBusiness> PostAsync(ViewModels.PrincipalBusinessViewModel entity)
        {
            var result =
                await ServiceBasePostAsync<ViewModels.PrincipalBusinessViewModel, Models.PrincipalBusiness>(entity);

            return result;
        }

        public async Task<Models.PrincipalBusiness> PutAsync(ViewModels.PrincipalBusinessViewModel entity)
        {
            var result =
                await ServiceBasePutAsync<ViewModels.PrincipalBusinessViewModel, Models.PrincipalBusiness>(entity);

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
