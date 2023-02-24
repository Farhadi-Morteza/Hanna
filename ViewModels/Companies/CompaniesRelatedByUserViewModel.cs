

namespace ViewModels
{
    public class CompaniesRelatedByUserViewModel
    {
        //public Guid CompanyId { get; set; }
        private IList<Guid>? _companiesId;
        public IList<Guid> CompaniesId
        {
            get
            {
                if( _companiesId == null )
                {
                    _companiesId =
                        new List<Guid>();
                }
                return _companiesId;
            }
        }
    }
}
