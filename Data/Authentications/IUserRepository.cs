using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Data.Authentications
{
    public interface IUserRepository : IRepositoryBase<Models.User>
    {
        Task<UserViewModel> GetUserByIdAsync(Guid id);
        Task<User> GetUserByUserName(string userName);
        Task<IEnumerable<UserViewModel>> GetUserExpectCurrentUserAsync(Guid currentUserId);
    }
}
