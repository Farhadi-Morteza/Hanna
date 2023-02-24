namespace Client.Services
{
    public class AuthService : ServiceBase
    {
        public AuthService(HttpClient http) : base(http)
        {
        }

        protected override string GetApiUrl()
        {
            return "Auth";
        }

        public async Task<ViewModels.UserViewModel> PostAsync(ViewModels.UserViewModel entity)
        {
            string query = "Register";

            var result =
                await ServiceBasePostAsync<ViewModels.UserViewModel, ViewModels.UserViewModel>(entity, query);

            return result;
        }

        public async Task<string> PostAsync(ViewModels.UserDto entity)
        {
            string query = "Login";

            var result =
                await ServiceBasePostAsync<ViewModels.UserDto, string>(entity, query:query);

            return result;
        }
    }
}
