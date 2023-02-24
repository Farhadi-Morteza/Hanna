using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels;

namespace Data.Products
{
    public class ProductIndicatorRepository : Repository<ProductIndicator>, IProductIndicatorRepository
    {
        internal ProductIndicatorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<ProductIndicatorViewModel>> GetIndexAsync()
        {
            var result =
                await DbSet.Include(current => current.Metric)
                .Where(w => w.IsDeleted == false)
                .Select(s => new ProductIndicatorViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    UnitConversion = s.UnitConversion,
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

        public async Task<ProductIndicatorViewModel> GetIndexByIdAsync(Guid id)
        {
            var result =
                await DbSet.Include(current => current.Metric)
                .Where(w => w.Id == id)
                .Select(s => new ProductIndicatorViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    UnitConversion = s.UnitConversion,
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

        public async Task<List<ProductIndicatorSelectViewModel>> GetSelectAsync()
        {
            var result =
                await DbSet.Where(current => current.IsActive == true && current.IsDeleted == false)
                .Select(s => new ProductIndicatorSelectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToListAsync();

            return result;
        }
    }
}
