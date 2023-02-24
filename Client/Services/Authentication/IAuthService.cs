using Models;

namespace Client.Services
{
    public interface IAuthService
    {
        Task<string> PostAsync(ViewModels.UserDto entity);
    }
}
