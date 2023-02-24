using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class ProductTypeController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public ProductTypeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("Select")]
        public async Task<ActionResult<IEnumerable<ViewModels.ProductTypeSelectViewModel>>> GetSelectAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ProductTypeRepository.GetSelectAsync();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(value: result);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
