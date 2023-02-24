using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    public interface IPrincipalBusinessRepository : IRepositoryBase<Models.PrincipalBusiness>
    {
        Task<List<Models.PrincipalBusiness>> GetAllActiveAsync();
        Task<List<ViewModels.PrincipalBusinessSelectViewModel>> GetSelectAsync();
    }
}
