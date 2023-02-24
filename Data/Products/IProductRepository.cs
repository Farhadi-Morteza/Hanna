using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Data.Products
{
    public interface IProductRepository : IRepositoryBase<Models.Product>
    {
        Task<List<ViewModels.ProductViewModel>> GetIndexAsync();
        Task<ProductViewModel> GetIndexByActivityIdAsync(Guid id);
        Task<ViewModels.ProductViewModel> GetIndexByIdAsync(Guid id);
        Task<List<ProductViewModel>> GetSelectAsync();
        Task<List<ProductSelectViewModel>> GetSelectByActivityIdAsync(Guid activityId);
        Task<List<ProductSelectViewModel>> test1();
        Task<List<Product>> test2();

        //Task<List<ViewModels.ProductActivityViewModel>> GetProductActivityAsync();
    }
}
