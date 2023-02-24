using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "User")]
    public class BusinessController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public BusinessController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.BusinessViewModel>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.BusinessRepository.GetIndexAsync();

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

        [HttpGet("{Id}")]
        public async Task<ActionResult<ViewModels.BusinessViewModel>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.BusinessRepository.GetIndexByIdAsync(id: id);//.GetByIdAsync(id: id);




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

        [HttpGet("Select")]
        public async Task<ActionResult<IEnumerable<ViewModels.BusinessSelectViewModel>>> GetSelectAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.BusinessRepository.GetSelectAsync();

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
        public async Task<ActionResult<ViewModels.BusinessViewModel>> PostAsync(ViewModels.BusinessViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.Business
                    {
                        Name = entity.Name,
                        IsActive = entity.IsActive,
                        PrincipalBusinessId = entity.PrincipalBusiness.Id,
                    };

                await UnitOfWork.BusinessRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.BusinessViewModel>> PutAsync(ViewModels.BusinessViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.BusinessRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;
                EditEntity.IsActive = entity.IsActive;
                EditEntity.PrincipalBusinessId = entity.PrincipalBusiness.Id;

                await UnitOfWork.BusinessRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.Business entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.BusinessRepository.DeleteAsync(entity);
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
                await UnitOfWork.BusinessRepository.DeleteByIdAsync(id: id);
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
