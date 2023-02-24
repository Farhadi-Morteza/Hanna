using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Data.Products
{
    public class PrincipalBusinessRepository : Data.Repository<Models.PrincipalBusiness>, IPrincipalBusinessRepository
    {
        internal PrincipalBusinessRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Task<List<PrincipalBusiness>> GetAllActiveAsync()
        {
            var result =
                DbSet.Where(current => current.IsActive == true && current.IsDeleted == false)
                .OrderBy(current => current.Name)
                .ToListAsync();

            return result;
        }

        public Task<List<PrincipalBusinessSelectViewModel>> GetSelectAsync()
        {
            var result =
                DbSet.Where(current => current.IsActive == true && current.IsDeleted == false)
                .Select(current => new PrincipalBusinessSelectViewModel()
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
