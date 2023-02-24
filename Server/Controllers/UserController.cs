using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    public class UserController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.UserViewModel>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.UserRepository.GetUserExpectCurrentUserAsync(UserId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModels.UserViewModel>> GetByIdAsync(Guid id)
        {
            try
            {
                var result =
                    await UnitOfWork.UserRepository.GetUserByIdAsync(id: id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
