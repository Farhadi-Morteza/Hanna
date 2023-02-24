using Microsoft.EntityFrameworkCore;

namespace Data.Schedules
{
    public class ActivityPlanRepository : Data.Repository<Models.ActivityPlan>, IActivityPlanRepository
    {
        internal ActivityPlanRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        public async Task<List<ViewModels.ActivityPlanIndexViewModel>> GetActivityPlanIndexByPlanIdAsync(Guid planId)
        {
            //var planId = Guid.Parse("143f4ce0-1330-4dcc-aaec-f7bb3b39e9a6");
            //var result =
            //    await DbSet
            //    .Include(p => p.Activity)
            //        .ThenInclude(c => c.Business)
            //            .ThenInclude(c => c.PrincipalBusiness)
            //    .Include(c => c.BusinessType)
            //    .Include(c => c.ProductActivityPlans)
            //        .ThenInclude(c => c.Product)
            //    .Where(current => current.IsDeleted == false && current.PlanId == planId)
            //    .OrderBy(order => order.InsertDate)
            //    .AsNoTracking()
            //    .ToListAsync();


            var result =
                await DbSet
                .Where(w => w.PlanId == planId && w.IsDeleted == false)
                .Select(s => new ViewModels.ActivityPlanIndexViewModel()
                {
                    Id = s.Id,
                    PlanId = s.PlanId,
                    PrincipalBusiness = s.Activity.Business.PrincipalBusiness.Name,
                    Business = s.Activity.Business.Name,
                    Activity = s.Activity.Name,
                    BusinessType = s.BusinessType.Name,
                    ProductActivityPlans = s.ProductActivityPlans
                    .Where(j => j.IsDeleted == false)
                    .Select(p => new ViewModels.ProductActivityPlanViewModel()
                    {
                        Id = p.Id,                        
                        ProductSelectViewModel = new ViewModels.ProductSelectViewModel()
                        {
                            Id = p.Product.Id,
                            Name = p.Product.Name
                        }
                    })
                    .ToList()
                })                
                .ToListAsync();

            return result;
        }
        public async Task<ViewModels.ActivityPlanViewModel> GetActivityPlanByIdAsync(Guid id)
        {
            var result =
                await DbSet
                    .Include(c => c.Plan)
                    .Include(c => c.Activity)
                    .Include(c => c.BusinessType)
                    .Where(w => w.Id == id && w.IsDeleted == false)
                    .Select(s => new ViewModels.ActivityPlanViewModel()
                    {
                        Id = s.Id,
                        ForecastLevel = s.ForecastLevel,
                        ForecastFinalPrice = s.ForecastFinalPrice,
                        Capacitylevel = s.Capacitylevel,                 
                        PlanTitel = new ViewModels.PlanTitelViewModel()
                        {
                            Id = s.Plan.Id,
                            Titel = s.Plan.Titel,
                            Year = s.Plan.Year.Name.ToString(),
                        },
                        ActivitySelectViewModel = new ViewModels.ActivitySelectViewModel()
                        {
                            Id = s.Activity.Id,
                            Name = s.Activity.Name,
                            ActivityIndicatorSelectViewModel = new ViewModels.ActivityIndicatorSelectViewModel()
                            {
                                Id = s.Activity.ActivityIndicator.Id,
                                Name = s.Activity.ActivityIndicator.Name
                            },
                            MetricSelectViewModel = new ViewModels.MetricSelectViewModel()
                            {
                                Id = s.Activity.ActivityIndicator.Metric.Id,
                                Name = s.Activity.ActivityIndicator.Metric.Name
                            }
                        },
                        BusinessType = new ViewModels.BusinessTypeSelectViewModel()
                        {
                            Id = s.BusinessType.Id,
                            Name = s.BusinessType.Name

                        }
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

            return result;

        }
        public async Task<ViewModels.ActivityPlanViewModel> GetActivityPlanByPlanIdAsync(Guid planId)
        {
            var result =
                await DbSet
                    .Where(w => w.Plan.Id == planId && w.IsDeleted == false)
                    .Select(s => new ViewModels.ActivityPlanViewModel()
                    {
                        PlanTitel = new ViewModels.PlanTitelViewModel()
                        {
                            Id = s.Plan.Id,
                            Titel = s.Plan.Titel,
                            Year = s.Plan.Year.Name.ToString(),
                        }
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

            return result;

        }
        public async Task<ViewModels.ActivityPlanTitelViewModel> GetActivityPlanTitelById(Guid id)
        {
            var result =
                await DbSet
                .Include(p => p.Activity)
                    .ThenInclude(c => c.Business)
                        .ThenInclude(c => c.PrincipalBusiness)
                .Include(c => c.BusinessType)
                .Include(c => c.Plan)
                    .ThenInclude(c => c.Year)
                .Where(current => current.IsDeleted == false && current.Id == id)
                .Select(s => new ViewModels.ActivityPlanTitelViewModel()
                {
                    Id = s.Id,
                    PlanId = s.Plan.Id,
                    ActivityId = s.Activity.Id,
                    PlanTitel = s.Plan.Titel,
                    Year = s.Plan.Year.Name.ToString(),
                    PrincipalBusiness = s.Activity.Business.PrincipalBusiness.Name,
                    Business = s.Activity.Business.Name,
                    Activity = s.Activity.Name,

                })                
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result;

        }
        public async Task<ViewModels.ActivityPlanSummaryViewModel> GetActivityPlanSummaryAsync(Guid id)
        {
            var result =
                await DbSet
                .Where(w => w.Id == id && w.IsDeleted == false)
                .Include(c => c.ProductActivityPlans)
                    .ThenInclude(c => c.Product)
                        .ThenInclude(c => c.ProductIndicator)
                            .ThenInclude(c => c.Metric)
                .Select(s => new ViewModels.ActivityPlanSummaryViewModel()
                {
                    ActivityPlanId = s.Id,
                    PlanId = s.Plan.Id,
                    ActivityId = s.Activity.Id,
                    PlanTitel = s.Plan.Titel,
                    Year = s.Plan.Year.Name.ToString(),
                    ForecastFinalPrice = s.ForecastFinalPrice,
                    ForecastLevel = s.ForecastLevel,
                    Capacitylevel = s.Capacitylevel,
                    PrincipalBusiness = s.Activity.Business.PrincipalBusiness.Name,
                    Business = s.Activity.Business.Name,
                    Activity = s.Activity.Name,
                    BusinessType = s.BusinessType.Name,
                    ActivityIndicator = s.Activity.ActivityIndicator.Name,
                    ActivityIndicatorMetric = s.Activity.ActivityIndicator.Metric.Name,
                    ProductActivityPlans = s.ProductActivityPlans                    
                    .Where(x => x.IsDeleted == false)
                    .Select(p => new ViewModels.ProductActivityPlanViewModel()
                    {
                        Id = p.Id,
                        ActivityPlanId = p.ActivityPlan.Id,
                        ForecastProduction = p.ForecastProduction,
                        ForecastSales = p.ForecastSales,
                        SalePerProductUnit = p.SalePerProductUnit,
                        PercentageOfSalesShare = p.PercentageOfSalesShare,
                        ProductSelectViewModel = new ViewModels.ProductSelectViewModel
                        {
                            Id = p.Product.Id,
                            Name = p.Product.Name,
                            ProductIndicatorSelectViewModel = new ViewModels.ProductIndicatorSelectViewModel()
                            {
                                Id = p.Product.ProductIndicator.Id,
                                Name = p.Product.ProductIndicator.Name,
                            },
                            MetricSelectViewModel = new ViewModels.MetricSelectViewModel()
                            {
                                Id = p.Product.ProductIndicator.Metric.Id,
                                Name = p.Product.ProductIndicator.Metric.Name,
                            },
                            ProductTypeSelectViewModel = new ViewModels.ProductTypeSelectViewModel
                            {
                                Id = p.Product.ProductType.Id,
                                Name = p.Product.ProductType.Name
                            }
                        }

                    })
                    .ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result;
        }

    }
}
