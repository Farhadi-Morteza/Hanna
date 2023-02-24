using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
    public class EmployeeRepository : Repository<Models.Employee>, IEmployeeRepository
    {
        internal EmployeeRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<Models.Employee>> AllReportsAsync(Guid id)
        {
            //List<Models.Employee> categories =
            //    await DbSet.ToListAsync();


            //List<Models.Employee> hierarchy = new List<Models.Employee>();

            //foreach(var category in categories)
            //{
            //    if(category.Reports != null && category.Reports.Any())
            //    {

            //    }
            //}

            //hierarchy = categories
            //    .Where(c => c.Id == id)
            //    .Select(c => new Models.Employee()
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        ManagerId = c.ManagerId,
            //        Manager = c.Manager,
            //        Reports = GetChildren(categories, c.Id),
            //    })
            //    .ToList();


            var hierarchy =
                await DbSet.FromSqlRaw(
                     @"WITH organization (id, name, title, managerid, below) AS (
                SELECT id, name, title, managerid, 0
                FROM dbo.Employees    
                WHERE Employees.Id = {0}        
                UNION ALL
                SELECT e.id, e.name, e.title, e.managerid, o.below + 1
                FROM dbo.Employees e    
                INNER JOIN organization o 
                    ON o.Id = e.ManagerId
            )
            SELECT * FROM organization", id)
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();

            return hierarchy;
        }

        public List<Models.Employee> GetChildren(List<Models.Employee> Comments, Guid managerId)
        { 
            var tt = Comments
                .Where(c => c.ManagerId == managerId)
                .Select(c => new Models.Employee
                {
                    Id = c.Id,
                    Name = c.Name,
                    Title = c.Title,
                    ManagerId = c.ManagerId,
                    Reports = GetChildren(Comments, managerId)
                })
                .ToList();

            return tt;
        }
    }
}
