using Microsoft.EntityFrameworkCore;

namespace Data.General
{
    public class YearRepository : Repository<Models.Year>, IYearRepository
    {
        internal YearRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Task<List<ViewModels.YearSelectViewModel>> GetSelectAsync()
        {
            var result =
                DbSet.Where(current => current.IsDeleted == false)
                .Select(current => new ViewModels.YearSelectViewModel()
                {
                    Id = current.Id,
                    Name = current.Name,
                })
                .ToListAsync();

            return result;
        }

        public Task<ViewModels.YearViewModel?> GetYearByYearName(int yearName)
        {
            var result =
                DbSet.Where(x => x.Name == yearName)
                .Select(s => new ViewModels.YearViewModel()
                {
                    Id = s.Id,
                    Name =  s.Name,
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
