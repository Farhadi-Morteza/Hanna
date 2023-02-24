using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    public class PrincipalBusinessController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public PrincipalBusinessController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.PrincipalBusiness>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.PrincipalBusinessRepository.GetAllAsync();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(value: result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Models.PrincipalBusiness>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.PrincipalBusinessRepository.GetByIdAsync(id: id);

                if (result == null)
                {
                    return NotFound(Resources.InformationMessages.NotFount);
                }

                return Ok(value: result);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpGet("Active")]
        public async Task<ActionResult<IEnumerable<Models.PrincipalBusiness>>> GetActiveAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.PrincipalBusinessRepository.GetAllActiveAsync();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(value: result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("Select")]
        public async Task<ActionResult<IEnumerable<ViewModels.PrincipalBusinessSelectViewModel>>> GetSelectAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.PrincipalBusinessRepository.GetSelectAsync();

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

        [HttpPost]
        public async Task<ActionResult<Models.PrincipalBusiness>> PostAsync(ViewModels.PrincipalBusinessViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.PrincipalBusiness
                    {
                        Name = entity.Name,
                        IsActive = entity.IsActive,
                    };

                await UnitOfWork.PrincipalBusinessRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Models.PrincipalBusiness>> PutAsync (ViewModels.PrincipalBusinessViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.PrincipalBusinessRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;
                EditEntity.IsActive = entity.IsActive;

                await UnitOfWork.PrincipalBusinessRepository.UpdateAsync(EditEntity);   
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync (Models.PrincipalBusiness entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.PrincipalBusinessRepository.DeleteAsync(entity);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteByIdAsync(Guid id)
        {
            try
            {
                await UnitOfWork.PrincipalBusinessRepository.DeleteByIdAsync(id: id);
                await UnitOfWork.SaveAsync();   

                return Ok(value: true);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }
    }
}
