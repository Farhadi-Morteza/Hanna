using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels;

namespace Data.General
{
    public class MetricRepository : Repository<Models.Metric>, IMetricRepository
    {
        internal MetricRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<Metric>> GetIndexAsync()
        {
            var result =
                await DbSet.Where(current => current.IsDeleted == false && current.IsActive == true)
                .OrderBy(current => current.Name)
                .ToListAsync();

            return result;
        }

        public Task<List<MetricSelectViewModel>> GetSelectAsync()
        {
            var result =
                DbSet.Where(current => current.IsDeleted == false && current.IsActive == true)
                .Select(current => new MetricSelectViewModel()
                {
                    Id = current.Id,
                    Name = current.Name,
                })
                .ToListAsync();

            return result;
        }
    }
}
