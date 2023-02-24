using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels;

namespace Data.Products
{
    public class BusinessRepository : Repository<Models.Business>, IBusinessRepository
    {
        internal BusinessRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<Business>> GetBusinesses()
        {
            var result =
               await DbSet.Include(c => c.PrincipalBusiness).OrderBy(o => o.PrincipalBusiness.Name).ToListAsync();

            return result;
        }

        public async Task<List<BusinessViewModel>> GetIndexAsync()
        {
            var result =
                await DbSet.Include(current => current.PrincipalBusiness)
                .Where(current => current.IsDeleted == false)
                .Select(c => new BusinessViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    PrincipalBusinessId = c.PrincipalBusinessId,
                    PrincipalBusiness = new PrincipalBusinessSelectViewModel()
                    {
                        Id = c.PrincipalBusiness.Id,
                        Name = c.PrincipalBusiness.Name,
                    }
                })
                .OrderBy(c => c.Name)
                .ToListAsync();

            return result;
        }

        public async Task<BusinessViewModel> GetIndexByIdAsync(Guid id)
        {
            var result =
                 await DbSet.Include(p => p.PrincipalBusiness)
                 .Where(c => c.Id == id)
                 .Select(c => new BusinessViewModel()
                 {
                     Id = c.Id,
                     Name = c.Name,
                     IsActive = c.IsActive,
                     PrincipalBusinessId = c.PrincipalBusinessId,
                     PrincipalBusiness = new PrincipalBusinessSelectViewModel()
                     {
                         Id = c.PrincipalBusiness.Id,
                         Name = c.PrincipalBusiness.Name,
                     }
                 })
                 .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<BusinessSelectViewModel>> GetSelectAsync()
        {
            var result =
                await DbSet.Where(current => current.IsActive == true && current.IsDeleted == false)
                .Select(current => new BusinessSelectViewModel()
                {
                    Id = current.Id,
                    Name = current.Name,
                })
                .OrderBy(current => current.Name)
                .ToListAsync();

            return result;
        }
    }
}
