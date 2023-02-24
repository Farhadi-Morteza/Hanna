
namespace Data
{
    public interface IUnitOfWork : IUnitOfWorkBase
    {
        Authentications.IUserRepository UserRepository { get; }

        Products.IPrincipalBusinessRepository PrincipalBusinessRepository { get; }
        Products.IBusinessRepository BusinessRepository { get; }
        Products.IBusinessTypeRepository BusinessTypeRepository { get; }
        Products.IActivityRepository ActivityRepository { get; }
        Products.IActivityIndicatorRepository ActivityIndicatorRepository { get; }
        Products.IProductRepository ProductRepository { get; }
        Products.IProductIndicatorRepository ProductIndicatorRepository { get; }
        Products.IProductTypeRepository ProductTypeRepository { get; }

        General.IMetricRepository MetricRepository { get; }
        General.IYearRepository YearRepository { get; }
        General.IEmployeeRepository EmployeeRepository { get; }

        Companies.ICompanyCategoryRepository CompanyCategoryRepository { get; }
        Companies.ICompanyRepository CompanyRepository { get; }

        General.IChatMessageRepository ChatMessageRepository { get; }

        //Products.IProductRepository ProductRepository { get; }
        //Public.ICountryRepository CountryRepository { get; }

        #region Schedules

        Schedules.IPlanRepository PlanRepository { get; }
        Schedules.IActivityPlanRepository ActivityPlanRepository { get; }
        Schedules.IProductActivityPlanRepository ProductActivityPlanRepository { get; }

        #endregion
    }
}
