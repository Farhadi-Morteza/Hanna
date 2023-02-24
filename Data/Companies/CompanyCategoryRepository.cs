

namespace Data.Companies
{
    public class CompanyCategoryRepository : Repository<Models.CompanyCategory>, ICompanyCategoryRepository
    {
        internal CompanyCategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
