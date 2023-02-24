using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class CompaniesController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public CompaniesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Company>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.CompanyRepository.GetIndexAsync();//.GetAllAsync();

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

        [HttpGet("Select{companyCategories}")]
        public async Task<ActionResult<IEnumerable<ViewModels.CompanySelectViewModel>>> GetSelectAsync(Data.Tools.Enums.CompanyCategories companyCategories)
        {
            try
            {
                var result =
                    await UnitOfWork.CompanyRepository.GetSelectAsync(companyCategories: companyCategories);

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
        public async Task<ActionResult<Models.Company>> PostAsync(ViewModels.CompanyViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var newEntity =
                    new Models.Company
                    {
                        Name = entity.Name,
                        CompanyCategoryId = entity.CompanyCategory.Id,
                        CompanyParentId = entity.CompanyParent == null ? null : entity.CompanyParent.Id,
                        CompanyCategory = null
                    };

                await UnitOfWork.CompanyRepository.InsertAsync(entity: newEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: newEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Models.Company>> PutAsync(ViewModels.CompanyViewModel entity)
        {
            if (entity == null)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }

            try
            {
                var EditEntity =
                    await UnitOfWork.CompanyRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;
                EditEntity.CompanyCategoryId = entity.CompanyCategory.Id;
                EditEntity.CompanyParentId = entity.CompanyParent == null ? null : entity.CompanyParent?.Id;

                await UnitOfWork.CompanyRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.Company entity)
        {
            if (entity == null)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }

            try
            {
                await UnitOfWork.CompanyRepository.DeleteAsync(entity);
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
                await UnitOfWork.CompanyRepository.DeleteByIdAsync(id: id);
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
