using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Data.Products
{
    public class ProductTypeRepository : RepositoryBase<Models.ProductType>, IProductTypeRepository
    {
        internal ProductTypeRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<ProductTypeSelectViewModel>> GetSelectAsync()
        {
            var result =
                await DbSet
                .Select(current => new ProductTypeSelectViewModel()
                {
                    Id = current.Id,
                    Name = current.Name,
                })
                .OrderBy(current => current.Name)
                .ToListAsync();

            return result;
        }
    }
}
