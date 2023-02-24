
using Microsoft.EntityFrameworkCore;

namespace Data.Schedules
{
    public class ProductActivityPlanRepository : Repository<Models.ProductActivityPlan>, IProductActivityPlanRepository
    {
        internal ProductActivityPlanRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        public async Task<List<Models.ProductActivityPlan>> GetProductActivityPlanIndexByActivityPlanIdAsync(Guid activityPlanId)
        {
            var result =
                await DbSet
                .Include(c => c.Product)
                .Where(x => x.IsDeleted == false && x.ActivityPlanId == activityPlanId)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }
        public async Task<ViewModels.ProductActivityPlanViewModel> GetProductActivityPlanByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Where(w => w.Id == id && w.IsDeleted == false)
                .Select(s => new ViewModels.ProductActivityPlanViewModel()
                {
                    Id = s.Id,
                    ActivityPlanId = s.ActivityPlanId,
                    ForecastProduction = s.ForecastProduction,
                    ForecastSales = s.ForecastSales,
                    PercentageOfSalesShare = s.PercentageOfSalesShare,
                    SalePerProductUnit = s.SalePerProductUnit,
                    ActivityPlanTitel = new ViewModels.ActivityPlanTitelViewModel()
                    {
                        Id = s.ActivityPlan.Id,
                        PlanId = s.ActivityPlan.Plan.Id,
                        ActivityId = s.ActivityPlan.Activity.Id,
                        PlanTitel = s.ActivityPlan.Plan.Titel,
                        Year = s.ActivityPlan.Plan.Year.Name.ToString(),
                        PrincipalBusiness = s.ActivityPlan.Activity.Business.PrincipalBusiness.Name,
                        Business = s.ActivityPlan.Activity.Business.Name,
                        Activity = s.ActivityPlan.Activity.Name,
                    },
                    ProductSelectViewModel = new ViewModels.ProductSelectViewModel()
                    {
                        Id = s.Product.Id,
                        Name = s.Product.Name,
                        ProductIndicatorSelectViewModel = new ViewModels.ProductIndicatorSelectViewModel()
                        {
                            Id = s.Product.ProductIndicator.Id,
                            Name = s.Product.ProductIndicator.Name
                        },
                        MetricSelectViewModel = new ViewModels.MetricSelectViewModel()
                        {
                            Id = s.Product.ProductIndicator.Metric.Id,
                            Name = s.Product.ProductIndicator.Metric.Name,
                        },
                        ProductTypeSelectViewModel = new ViewModels.ProductTypeSelectViewModel()
                        {
                            Id = s.Product.ProductType.Id,
                            Name = s.Product.ProductType.Name,
                        }
                        
                    }
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result;
        }
        public async Task<ViewModels.ProductActivityPlanViewModel> GetProductActivityPlanByActivityPlanIdAsync(Guid activityPlanId)
        {
            var result =
                await DbSet
                .Where(w => w.ActivityPlan.Id == activityPlanId && w.IsDeleted == false)
                .Select(s => new ViewModels.ProductActivityPlanViewModel()
                {
                    ActivityPlanTitel = new ViewModels.ActivityPlanTitelViewModel()
                    {
                        Id = s.ActivityPlan.Id,
                        PlanId = s.ActivityPlan.Plan.Id,
                        ActivityId = s.ActivityPlan.Activity.Id,
                        PlanTitel = s.ActivityPlan.Plan.Titel,
                        Year = s.ActivityPlan.Plan.Year.Name.ToString(),
                        PrincipalBusiness = s.ActivityPlan.Activity.Business.PrincipalBusiness.Name,
                        Business = s.ActivityPlan.Activity.Business.Name,
                        Activity = s.ActivityPlan.Activity.Name,
                    }
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
