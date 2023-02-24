using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class ActivityController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public ActivityController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //[HttpGet, Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Activity>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ActivityRepository.GetIndexAsync();

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
        public async Task<ActionResult<ViewModels.ActivityViewModel>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.ActivityRepository.GetIndexByIdAsync(id: id);

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
        public async Task<ActionResult<IEnumerable<ViewModels.ActivitySelectViewModel>>> GetSelectAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ActivityRepository.GetSelectAsync();

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
        public async Task<ActionResult<ViewModels.ActivityViewModel>> PostAsync(ViewModels.ActivityViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.Activity
                    {
                        Name = entity.Name,
                        IsActive = entity.IsActive,
                        BusinessId = entity.Business.Id,
                        Business = null,
                        ActivityIndicatorId = entity.ActivityIndicator.Id,
                        //Products = entity.Products,
                    };

                await UnitOfWork.ActivityRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();
                return Ok(value: NewEntity);
                            
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.ActivityViewModel>> PutAsync(ViewModels.ActivityViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.ActivityRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;
                EditEntity.IsActive = entity.IsActive;
                EditEntity.BusinessId = entity.Business.Id;
                EditEntity.ActivityIndicatorId = entity.ActivityIndicator.Id;

                await UnitOfWork.ActivityRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.Activity entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.ActivityRepository.DeleteAsync(entity);
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
                await UnitOfWork.ActivityRepository.DeleteByIdAsync(id: id);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPost("ActivityProduct")]
        public async Task<ActionResult<ViewModels.ActivityViewModel>> PostActivityProductAsync(ViewModels.ActivityProductViewModel entity)
        {

            try
            {
                var activity =
                    await UnitOfWork.ActivityRepository.GetByIdAsync(entity.ActivityId);

                if (activity == null)
                {
                    return NotFound();
                }

                var product =
                    await UnitOfWork.ProductRepository.GetByIdAsync(entity.ProductId);

                if (product == null)
                {
                    return NotFound();
                }

                activity.Products.Add(product);

                await UnitOfWork.SaveAsync();
                return Ok(value: activity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete("DeleteActivityProduct")]
        public async Task<ActionResult<bool>> DeleteActivityProductAsync(ViewModels.ActivityProductViewModel entity)
        {

            try
            {
                var activity =
                    await UnitOfWork.ActivityRepository.GetIndexByIdAsync(entity.ActivityId);

                //var aa =
                //    await UnitOfWork.ActivityRepository.GetByIdAsync(entity.ActivityId);

                if (activity == null)
                {
                    return NotFound();
                }

                var product =
                    await UnitOfWork.ProductRepository.GetByIdAsync(entity.ProductId);

                if (product == null)
                {
                    return NotFound();
                }

                activity.Products.RemoveAt(1);
                
            

                //await UnitOfWork.ActivityRepository.DeleteAsync(aa);

                await UnitOfWork.SaveAsync();

                return Ok(value: activity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }
    }
}
