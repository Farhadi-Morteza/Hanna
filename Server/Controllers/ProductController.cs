using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    public class ProductController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.ProductViewModel>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ProductRepository.GetIndexAsync();

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

        [HttpGet("Test1")]
        public async Task<ActionResult<IEnumerable<ViewModels.ProductSelectViewModel>>> GetTest1()
        {
            var result =
                await UnitOfWork.ProductRepository.test1();
            return result;
        }
        [HttpGet("Test2")]
        public async Task<ActionResult<IEnumerable<Models.Product>>> GetTest2()
        {
            var result =
                await UnitOfWork.ProductRepository.test2();
            return result;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ViewModels.ProductViewModel>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.ProductRepository.GetIndexByIdAsync(id: id);

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
        public async Task<ActionResult<IEnumerable<ViewModels.ProductViewModel>>> GetSelectAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ProductRepository.GetSelectAsync();

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

        [HttpGet("SelectByActivityId/{ActivityId}")]
        public async Task<ActionResult<IEnumerable<ViewModels.ProductSelectViewModel>>> GetSelectByActivityId(Guid activityId)
        {
            try
            {
                var result =
                    await UnitOfWork.ProductRepository.GetSelectByActivityIdAsync(activityId: activityId);

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
        public async Task<ActionResult<ViewModels.ProductViewModel>> PostAsync(ViewModels.ProductViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.Product
                    {
                        Name = entity.Name,
                        IsActive = entity.IsActive,
                        ProductTypeId = entity.ProductType.Id,
                        ProductIndicatorId = entity.ProductIndicator.Id,
                        //ActivityId = entity.Activity.Id,
                    };

                await UnitOfWork.ProductRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.ProductViewModel>> PutAsync(ViewModels.ProductViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.ProductRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;
                EditEntity.IsActive = entity.IsActive;
                EditEntity.ProductTypeId = entity.ProductType.Id;
                EditEntity.ProductIndicatorId = entity.ProductIndicator.Id;
                //EditEntity.ActivityId = entity.Activity.Id;

                await UnitOfWork.ProductRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.Product entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.ProductRepository.DeleteAsync(entity);
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
                await UnitOfWork.ProductRepository.DeleteByIdAsync(id: id);
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
