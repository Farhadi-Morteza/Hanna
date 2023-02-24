using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
    public interface IEmployeeRepository : IRepositoryBase<Models.Employee>
    {
        Task<List<Employee>> AllReportsAsync(Guid id);
    }
}
