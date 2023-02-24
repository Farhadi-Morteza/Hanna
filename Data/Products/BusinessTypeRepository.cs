
using Microsoft.EntityFrameworkCore;

namespace Data.Products
{
    public class BusinessTypeRepository : Repository<Models.BusinessType>, IBusinessTypeRepository
    {
        internal BusinessTypeRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<ViewModels.BusinessTypeSelectViewModel>> GetSelectAsync()
        {
            var result =
                await DbSet.Where(current =>  current.IsDeleted == false)
                .Select(current => new ViewModels.BusinessTypeSelectViewModel()
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
