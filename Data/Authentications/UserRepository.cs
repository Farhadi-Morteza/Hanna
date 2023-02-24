using Microsoft.EntityFrameworkCore;

namespace Data.Authentications
{
    public class UserRepository : Data.Repository<Models.User>, IUserRepository
    {
        internal UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Models.User> GetUserByUserName(string userName)
        {
            var result =
                await DbSet
                .Where(c => c.Username.ToLower() == userName.ToLower())
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<ViewModels.UserViewModel>> GetUserExpectCurrentUserAsync(Guid currentUserId)
            {
            var result =
                await DbSet
                .Where(user => user.Id != currentUserId)
                .Select(s => new ViewModels.UserViewModel()
                {
                    FullName = s.FullName,
                    Company = new ViewModels.CompanySelectViewModel() 
                    {
                        Id = s.Company.Id,
                        Name = s.Company.Name,
                    },
                    Admin = s.Admin
                })
                .ToListAsync();

            return result;
        }

        public async Task<ViewModels.UserViewModel> GetUserByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Where(user => user.Id == id)
                .Select(s => new ViewModels.UserViewModel()
                {
                    FullName = s.FullName,
                    Company = new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Company.Id,
                        Name = s.Company.Name,
                    },
                    Admin = s.Admin
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
