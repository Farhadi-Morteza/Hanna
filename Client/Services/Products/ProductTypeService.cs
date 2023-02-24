namespace Client.Services
{
    public class ProductTypeService : ServiceBase
    {
        public ProductTypeService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "ProductType";
        }

        public async Task<IList<ViewModels.ProductTypeSelectViewModel>> GetSelectAsync()
        {
            string query = $"Select";
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.ProductTypeSelectViewModel>>(query: query);

            return result;
        }
    }
}
