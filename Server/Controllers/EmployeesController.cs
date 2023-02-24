using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class EmployeesController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public EmployeesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Employee>>> GetEmployees()
        {
            Guid id = Guid.Parse("F786EDAA-921F-413C-9953-7129F2BBE4EA");
            var result =
                await UnitOfWork.EmployeeRepository.AllReportsAsync(id: id);

            return result;
        }
    }
}
