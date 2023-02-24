using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels;

namespace Data.Products
{
    public class ActivityIndicatorRepository : Repository<ActivityIndicator>, IActivityIndicatorRepository
    {
        public ActivityIndicatorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<ActivityIndicatorViewModel>> GetIndexAsync()
        {
            var result =
                await DbSet.Include(current => current.Metric)
                .Where(w => w.IsDeleted == false)
                .Select(s => new ActivityIndicatorViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    MetricId = s.MetricId,
                    Metric = new MetricSelectViewModel()
                    {
                        Id = s.Metric.Id,
                        Name = s.Metric.Name,
                    }
                })
                .ToListAsync();

            return result;
        }

        public async Task<ActivityIndicatorViewModel> GetIndexByIdAsync(Guid id)
        {
            var result =
                await DbSet.Include(current => current.Metric)
                .Where(w => w.Id == id)
                .Select(s => new ActivityIndicatorViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    MetricId = s.MetricId,
                    Metric = new MetricSelectViewModel()
                    {
                        Id = s.Metric.Id,
                        Name = s.Metric.Name,
                    }
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<ActivityIndicatorSelectViewModel>> GetSelectAsync()
        {
            var result =
                await DbSet.Where(current => current.IsActive == true && current.IsDeleted == false)
                .Select(s => new ActivityIndicatorSelectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToListAsync();

            return result;
        }
    }
}
