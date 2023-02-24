using Data;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class CompanyCategoryController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public CompanyCategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.CompanyCategory>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.CompanyCategoryRepository.GetAllAsync();

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
        public async Task<ActionResult<Models.CompanyCategory>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.CompanyCategoryRepository.GetByIdAsync(id: id);

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


        [HttpPost]
        public async Task<ActionResult<Models.CompanyCategory>> PostAsync(Models.CompanyCategory entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.CompanyCategory
                    {
                        Name = entity.Name,
                    };

                await UnitOfWork.CompanyCategoryRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Models.CompanyCategory>> PutAsync(Models.CompanyCategory entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.CompanyCategoryRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;

                await UnitOfWork.CompanyCategoryRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.CompanyCategory entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.CompanyCategoryRepository.DeleteAsync(entity);
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
                await UnitOfWork.CompanyCategoryRepository.DeleteByIdAsync(id: id);
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
