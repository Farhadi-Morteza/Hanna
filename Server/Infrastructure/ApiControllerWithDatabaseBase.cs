
namespace Infrastructure
{

    public class ApiControllerWithDatabaseBase : ApiControllerBase
    {
        public ApiControllerWithDatabaseBase(Data.IUnitOfWork unitOfWork): base()
        {
            UnitOfWork = unitOfWork;
            
        }
        protected Data.IUnitOfWork UnitOfWork { get; }

        //protected Task<List<Models.Company>> Companies => UnitOfWork.CompanyRepository.GetRecursiveAsync(id: UserId);
        protected async Task<IEnumerable<Models.Company>> GetCompaniesRecursive()
        {
            var result =
                await UnitOfWork.CompanyRepository.GetRecursiveAsync(id: CompanyId);

            return result;
        }

        private Task<List<Models.Company>>? _companies = null;
        public Task<List<Models.Company>> CompaniesRelatedOfUser
        {
            get
            {
                if(_companies == null)
                {
                    _companies = UnitOfWork.CompanyRepository.GetRecursiveAsync(id: CompanyId);
                }
                return _companies;
            }
        }
    }
}
