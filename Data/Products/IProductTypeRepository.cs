using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    public interface IProductTypeRepository : IRepositoryBase<Models.ProductType>
    {
        Task<List<ViewModels.ProductTypeSelectViewModel>> GetSelectAsync();
    }
}
