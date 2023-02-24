using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Companies
{
    public class CompanyRepository : Data.Repository<Models.Company>, ICompanyRepository
    {
        internal CompanyRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<Models.Company>> GetIndexAsync()
        {
            //var com = 
            //    await DbSet.Where(x => x.Name.StartsWith("c_")).ToSelfHierarchyList(x => x.Company);

            var result =
                await DbSet
                .Include(p => p.CompanyCategory)
                .Where(w => w.IsDeleted == false)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<List<ViewModels.CompanySelectViewModel>> GetSelectAsync(Tools.Enums.CompanyCategories? companyCategories)
        {
            var result =
                new List<ViewModels.CompanySelectViewModel>();
            
            if (companyCategories == null || companyCategories == Tools.Enums.CompanyCategories.All)
            {
                result =
                    await DbSet
                        .Where(c => c.IsDeleted == false )
                        .Select(s => new ViewModels.CompanySelectViewModel()
                        {
                            Id = s.Id,
                            Name = s.Name,
                        })
                    .ToListAsync();
            }
            else if(companyCategories == Tools.Enums.CompanyCategories.Holding)
            {
                result =
                    await DbSet.Where(c => c.IsDeleted == false && c.CompanyCategory.Name == Constant.CompanyCategories.Holding)
                    .Select(s => new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .ToListAsync();                
            }
            else if (companyCategories == Tools.Enums.CompanyCategories.Company)
            {
                result =
                    await DbSet.Where(c => c.IsDeleted == false && c.CompanyCategory.Name == Constant.CompanyCategories.Company)
                    .Select(s => new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .ToListAsync();
            }
            else if (companyCategories == Tools.Enums.CompanyCategories.Collection)
            {
                result =
                    await DbSet.Where(c => c.IsDeleted == false && c.CompanyCategory.Name == Constant.CompanyCategories.Collection)
                    .Select(s => new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .ToListAsync();
            }
            else if (companyCategories == Tools.Enums.CompanyCategories.Subcollection)
            {
                result =
                    await DbSet.Where(c => c.IsDeleted == false && c.CompanyCategory.Name == Constant.CompanyCategories.Subcollection)
                    .Select(s => new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .ToListAsync();
            }
            else if (companyCategories == Tools.Enums.CompanyCategories.Part)
            {
                result =
                    await DbSet.Where(c => c.IsDeleted == false && c.CompanyCategory.Name == Constant.CompanyCategories.Part)
                    .Select(s => new ViewModels.CompanySelectViewModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .ToListAsync();
            }

            return result;
        }

        public async Task<List<Models.Company>> GetRecursiveAsync(Guid id)
        {
            try
            {
                var hierarchy =
                    await DbSet.FromSqlRaw(
                        @"WITH organization 
                        (
	                        id, 
	                        name, 
	                        CompanyParentId,
	                        CompanyCategoryId,
	                        IsDeleted,
	                        DeleteUserId,
	                        DeleteDate,
	                        InsertUserId,
	                        InsertDate,
	                        UpdateUserId,
	                        UpdateDate                
                        ) 
                AS (
                SELECT *
                FROM dbo.Companies    
                WHERE Companies.Id = {0}        
                UNION ALL
                SELECT e.*
                FROM dbo.Companies e    
                INNER JOIN organization o 
                    ON o.Id = e.CompanyParentId
            )
            SELECT * FROM organization", id)
                    .AsNoTracking()
                    .ToListAsync();

                return hierarchy;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
