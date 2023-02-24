namespace Client.Services
{
    public class UserService : ServiceBase
    {
        public UserService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "User";
        }

        public async Task<IList<ViewModels.UserViewModel>> GetAsync()
        {
            var result =
                await ServiceBaseGetAsync<IList<ViewModels.UserViewModel>>();

            return result;
        }

        public async Task<ViewModels.UserViewModel> GetByIdAsync(Guid id)
        {
            string query = $"/{id}";
            var result =
                await ServiceBaseGetAsync<ViewModels.UserViewModel>(query);

            return result;
        }
    }
}
