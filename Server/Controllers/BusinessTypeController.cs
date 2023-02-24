
using Microsoft.AspNetCore.Mvc;
using Data;

namespace Server.Controllers
{
    public class BusinessTypeController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public BusinessTypeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.BusinessTypeViewModel>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.BusinessTypeRepository.GetAllAsync();

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
        public async Task<ActionResult<IEnumerable<ViewModels.BusinessTypeViewModel>>> GetAsync(Guid id)
        {
            try
            {
                var result =
                    await UnitOfWork.BusinessTypeRepository.GetByIdAsync(id: id);

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

        [HttpGet("Select")]
        public async Task<ActionResult<IEnumerable<ViewModels.BusinessTypeSelectViewModel>>> GetSelectAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.BusinessTypeRepository.GetSelectAsync();

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
        public async Task<ActionResult<ViewModels.BusinessTypeViewModel>> PostAsync(ViewModels.BusinessTypeViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.BusinessType
                    {
                        Name = entity.Name,
                        IsActive = entity.IsActive,
                    };

                await UnitOfWork.BusinessTypeRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.BusinessTypeViewModel>> PutAsync(ViewModels.BusinessTypeViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.BusinessTypeRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;
                EditEntity.IsActive = entity.IsActive;

                await UnitOfWork.BusinessTypeRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

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
                await UnitOfWork.BusinessTypeRepository.DeleteByIdAsync(id: id);
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
