
using Microsoft.EntityFrameworkCore;

namespace Data.Schedules
{
    public class PlanRepository : Repository<Models.Plan>, IPlanRepository
    {
        internal PlanRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<ViewModels.PlanViewModel>> GetSuggestedPlanAsync()
        {
            var result =
                await DbSet
                .Include(current => current.Company)
                .Include(current => current.Year)
                .Where(current => current.IsDeleted == false && current.PlanCheckout == false)
                .OrderBy(current => current.InsertDate)
                .Select(s => new ViewModels.PlanViewModel()
                {
                    Id = s.Id,
                    Titel = s.Titel,
                    Company = new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Company.Id,
                        Name = s.Company.Name,
                    },
                    Year = new ViewModels.YearSelectViewModel()
                    {
                        Id = s.Year.Id,
                        Name = s.Year.Name
                    }

                })
            .AsNoTracking()
            .ToListAsync();

            return result;
        }

        public async Task<List<ViewModels.PlanViewModel>> GetCheckoutPlanAsync()
        {
            var result =
                await DbSet
                .Include(current => current.Company)
                .Include(current => current.Year)
                .Where(current => current.IsDeleted == false && current.PlanCheckout == true && current.PlanApproval == false)
                .OrderBy(current => current.InsertDate)
                .Select(s => new ViewModels.PlanViewModel()
                {
                    Id = s.Id,
                    Titel = s.Titel,
                    Company = new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Company.Id,
                        Name = s.Company.Name,
                    },
                    Year = new ViewModels.YearSelectViewModel()
                    {
                        Id = s.Year.Id,
                        Name = s.Year.Name
                    }

                })
            .AsNoTracking()
            .ToListAsync();

            return result;
        }

        public async Task<ViewModels.PlanViewModel> GetIndexByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Include(current => current.Company)
                .Include(current => current.Year)
                .Where(current => current.IsDeleted == false && current.Id == id)
                .Select(s => new ViewModels.PlanViewModel()
                {
                    Id = s.Id,
                    Titel = s.Titel,
                    Company = new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Company.Id,
                        Name = s.Company.Name,
                    },
                    Year = new ViewModels.YearSelectViewModel()
                    {
                        Id = s.Year.Id,
                        Name = s.Year.Name
                    }

                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<ViewModels.PlanActivityViewModel> GetPlan_ActivityPlanByPlanIdAsync(Guid id)
        {

            var result =
                await DbSet        
                .Where(w => w.IsDeleted == false && w.Id == id)
                .SelectMany(p => p.ActivityPlans.DefaultIfEmpty(), (p, b) => new ViewModels.PlanActivityViewModel()
                {
                    Id = p.Id,
                    Titel = p.Titel,
                    FinalApproval = p.FinalApproval,
                    PlanApproval = p.PlanApproval,
                    BreakApproval = p.BreakApproval,
                    Company = new ViewModels.CompanySelectViewModel() { Id = p.Company.Id, Name = p.Company.Name },
                    Year = new ViewModels.YearSelectViewModel() { Id = p.Year.Id, Name = p.Year.Name },
                    
                    ActivityPlanId = b.Id,

                    ActivityPlan = new ViewModels.ActivityPlanViewModel()
                    {
                        Id = b.Id,
                        Capacitylevel = b.Capacitylevel,
                        ForecastFinalPrice = b.ForecastFinalPrice,
                        ForecastLevel = b.ForecastLevel,
                        ActivitySelectViewModel = new ViewModels.ActivitySelectViewModel()
                        {
                            Id = b.Activity.Id,
                            Name = b.Activity.Name,
                        },
                        BusinessType = new ViewModels.BusinessTypeSelectViewModel()
                        {
                            Id = b.BusinessType.Id,
                            Name = b.BusinessType.Name
                        },

                    }
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> SavedLastTime(Guid companyId, Guid yearId)
        {
            var result =
                await DbSet
                    .Where(x => x.CompanyId == companyId && x.YearId == yearId)
                    .FirstOrDefaultAsync();

            if (result == null)
                return false;
            else
                return true;
        }

        public async Task<Models.Plan> GetPlanActivityIndexByPlanIdAsync(Guid id)
        {
            var result =
                 await DbSet
                 .Include(x => x.Company)
                 .Include(x => x.Year)
                 .Include(x => x.ActivityPlans)
                     .ThenInclude(x => x.ProductActivityPlans)
                        .ThenInclude(x => x.Product)
                 .Include(x => x.ActivityPlans)
                     .ThenInclude(x => x.BusinessType)
                 .Include(x => x.ActivityPlans)
                     .ThenInclude(t => t.Activity)
                         .ThenInclude(t => t.Business)
                             .ThenInclude(t => t.PrincipalBusiness)
                 .AsNoTracking()
                .Where(C => C.IsDeleted == false && C.Id == id)
                .OrderBy(o => o.InsertDate)
                .FirstOrDefaultAsync();

            

            return result;
                
        }

        public async Task<ViewModels.PlanTitelViewModel> GetPlanTitelByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Include(c => c.Year)
                .Include(c => c.Company)
                .Where(w => w.IsDeleted == false && w.Id == id)
                .Select(s => new ViewModels.PlanTitelViewModel()
                {
                    Id = s.Id,
                    Titel = s.Titel,
                    Company = s.Company.Name,
                    Year = s.Year.Name.ToString(),
                    PlanCheckout = s.PlanCheckout,
                    PlanApproval = s.PlanApproval,
                    BreakCheckout = s.BreakCheckout,
                    BreakApproval = s.BreakApproval,
                    FinalApproval = s.FinalApproval,
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
