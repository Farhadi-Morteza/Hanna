using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels;

namespace Data.Products
{
    public class AcitvityRepository : Repository<Models.Activity>, IActivityRepository
    {
        internal AcitvityRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<Activity>> GetIndexAsync()
        {
            var result =
                await DbSet
                .Include(p => p.Business)
                .Include(p => p.ActivityIndicator)
                .Include(p => p.Products)
                .Where(current => current.IsDeleted == false)
                .OrderBy(order => order.InsertDate)
                .AsNoTracking()
                .ToListAsync();

            return result;
            //var result =
            //    await DbSet
            //    .Include(current => current.Business)
            //    .Include(current => current.ActivityIndicator)
            //    .Include(current => current.Products)
            //    .Where(w => w.IsDeleted == false)
            //    .Select(s => new ActivityViewModel()
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        IsActive = s.IsActive,
            //        BusinessId = s.BusinessId,
            //        ProductCount = s.Products.Count(),
            //        Business = new BusinessSelectViewModel()
            //        {
            //            Id = s.Business.Id,
            //            Name = s.Business.Name,
            //        },
            //        ActivityIndicatorId = s.ActivityIndicatorId,
            //        ActivityIndicator = new ActivityIndicatorSelectViewModel()
            //        {
            //            Id = s.ActivityIndicator.Id,
            //            Name= s.ActivityIndicator.Name,
            //        }
            //    })
            //    .OrderBy(o => o.Name)
            //    .ToListAsync();   

            //return result;
        }

        public async Task<Activity> GetMyIndexAsync(Guid id)
        {
            var result =
                await DbSet
                .Include(p => p.Products)
                .Where(w => w.IsDeleted == false && w.Id == id)
                .OrderBy(order => order.InsertDate)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<ActivityViewModel> GetIndexByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Include(current => current.Business)
                .Include(current => current.ActivityIndicator)
                .Include(current => current.Products)
                .Where(w => w.IsDeleted == false && w.Id == id)
                .Select(s => new ActivityViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    Business = new BusinessSelectViewModel()
                    {
                        Id = s.Business.Id,
                        Name = s.Business.Name,
                    },
                    ActivityIndicator = new ActivityIndicatorSelectViewModel()
                    {
                        Id = s.ActivityIndicator.Id,
                        Name = s.ActivityIndicator.Name,
                    },
                    Products = s.Products
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<ActivitySelectViewModel>> GetSelectAsync()
        {
            var result =
                await DbSet
                .Include(p => p.ActivityIndicator)
                .ThenInclude(p => p.Metric)
                .Where(current => current.IsActive == true && current.IsDeleted == false)
                .Select(s => new ViewModels.ActivitySelectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name, 
                    ActivityIndicatorSelectViewModel = new ActivityIndicatorSelectViewModel()
                    {
                        Id = s.ActivityIndicator.Id,
                        Name = s.ActivityIndicator.Name,
                        
                    },
                    MetricSelectViewModel = new MetricSelectViewModel()
                    {
                        Id = s.ActivityIndicator.Metric.Id,
                        Name = s.ActivityIndicator.Metric.Name,
                    }
                    
                })
                .OrderBy(o => o.Name)
                .ToListAsync();

            return result;
        }


    }
}
