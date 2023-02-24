using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Data.Products
{
    public class ProductRepository : Repository<Models.Product>, IProductRepository
    {
        internal ProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<ProductViewModel>> GetIndexAsync()
        {
            var result =
                await DbSet
                .Include(current => current.ProductType)
                .Include(current => current.ProductIndicator)
                //.Include(current => current.Activity)
                .Where(w => w.IsDeleted == false)
                .Select(s => new ProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    ProductType = new ProductTypeSelectViewModel()
                    {
                        Id = s.ProductType.Id,
                        Name = s.ProductType.Name,
                    },
                    ProductIndicator = new ProductIndicatorSelectViewModel()
                    {
                        Id = s.ProductIndicator.Id,
                        Name = s.ProductIndicator.Name,
                    },
                    //ActivityId = s.Activity.Id,
                    //Activity = new ActivitySelectViewModel()
                    //{
                    //    Id = s.Activity.Id,
                    //    Name = s.Activity.Name,
                    //}
                })
                .OrderBy(o => o.Name)
                .ToListAsync();

            return result;
        }

        public async Task<List<ProductViewModel>> GetSelectAsync()
        {
            var result =
                await DbSet
                .Include(current => current.ProductType)
                .Include(current => current.ProductIndicator)
                //.Include(current => current.Activity)
                .Where(w => w.IsDeleted == false && w.IsActive == true)
                .Select(s => new ProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    ProductType = new ProductTypeSelectViewModel()
                    {
                        Id = s.ProductType.Id,
                        Name = s.ProductType.Name,
                    },
                    ProductIndicator = new ProductIndicatorSelectViewModel()
                    {
                        Id = s.ProductIndicator.Id,
                        Name = s.ProductIndicator.Name,
                    },
                    //ActivityId = s.Activity.Id,
                    //Activity = new ActivitySelectViewModel()
                    //{
                    //    Id = s.Activity.Id,
                    //    Name = s.Activity.Name,
                    //}
                })
                .OrderBy(o => o.Name)
                .ToListAsync();

            return result;
        }

        public async Task<List<ViewModels.ProductSelectViewModel>> GetSelectByActivityIdAsync(Guid activityId)
        {
            var result =
                await DbSet
                .Include(c => c.Activities)
                .Where(product => product.Activities.Select(activity => activity.Id).Contains(activityId))
                .Select(s => new ViewModels.ProductSelectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ProductTypeSelectViewModel = new ProductTypeSelectViewModel()
                    {
                        Id = s.ProductType.Id,
                        Name = s.ProductType.Name,
                    },
                    ProductIndicatorSelectViewModel = new ProductIndicatorSelectViewModel()
                    {
                        Id = s.ProductIndicator.Id,
                        Name = s.ProductIndicator.Name,
                    },
                    MetricSelectViewModel = new MetricSelectViewModel()
                    {
                        Id = s.ProductIndicator.Metric.Id,
                        Name = s.ProductIndicator.Metric.Name
                    }
                })
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<List<ViewModels.ProductSelectViewModel>> test1()
        {
            Guid activityId = Guid.Parse("5c622586-d8af-4a30-995a-f9e10702fae5");
            var result =
                await DbSet
                .Include(c => c.Activities)
                .Where(product => product.Activities.Select(activity => activity.Id).Contains(activityId))
                .Select(s => new ViewModels.ProductSelectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ProductTypeSelectViewModel = new ProductTypeSelectViewModel()
                    {
                        Id = s.ProductType.Id,
                        Name = s.ProductType.Name,
                    },
                    ProductIndicatorSelectViewModel = new ProductIndicatorSelectViewModel()
                    {
                        Id = s.ProductIndicator.Id,
                        Name = s.ProductIndicator.Name,
                    },
                    MetricSelectViewModel = new MetricSelectViewModel()
                    {
                        Id = s.ProductIndicator.Metric.Id,
                        Name = s.ProductIndicator.Metric.Name
                    }
                })
                .AsNoTracking()
                .ToListAsync();
                

            return result;
        }

        public async Task<List<Models.Product>> test2()
        {
            Guid activityId = Guid.Parse("ece2448d-d948-49ba-b61e-03fed2dde3fb");
            var result =
                await DbSet
                .Include(c => c.Activities.Where(activity => activity.Id.Equals(activityId)))                
                .ToListAsync();

            return result;
        }

        public async Task<ProductViewModel> GetIndexByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Include(current => current.ProductType)
                .Include(current => current.ProductIndicator)
                //.Include(current => current.Activity)
                .Where(w => w.IsDeleted == false && w.Id == id)
                .Select(s => new ProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    ProductType = new ProductTypeSelectViewModel()
                    {
                        Id = s.ProductType.Id,
                        Name = s.ProductType.Name,
                    },
                    ProductIndicator = new ProductIndicatorSelectViewModel()
                    {
                        Id = s.ProductIndicator.Id,
                        Name = s.ProductIndicator.Name,
                    },
                    //ActivityId = s.Activity.Id,
                    //Activity = new ActivitySelectViewModel()
                    //{
                    //    Id = s.Activity.Id,
                    //    Name = s.Activity.Name,
                    //}
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<ProductViewModel> GetIndexByActivityIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Include(current => current.ProductType)
                .Include(current => current.ProductIndicator)
                //.Include(current => current.Activity)
                //.Where(w => w.IsDeleted == false && w.ActivityId == id)
                .Where(w => w.IsDeleted ==    false)
                .Select(s => new ProductViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    ProductType = new ProductTypeSelectViewModel()
                    {
                        Id = s.ProductType.Id,
                        Name = s.ProductType.Name,
                    },
                    ProductIndicator = new ProductIndicatorSelectViewModel()
                    {
                        Id = s.ProductIndicator.Id,
                        Name = s.ProductIndicator.Name,
                    },
                    //ActivityId = s.Activity.Id,
                    //Activity = new ActivitySelectViewModel()
                    //{
                    //    Id = s.Activity.Id,
                    //    Name = s.Activity.Name,
                    //}
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}