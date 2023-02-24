using Data;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class ProductActivityPlansController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public ProductActivityPlansController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ProductActivityPlan>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ProductActivityPlanRepository.GetAllAsync();

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
        public async Task<ActionResult<ViewModels.ProductActivityPlanViewModel>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.ProductActivityPlanRepository.GetProductActivityPlanByIdAsync(id);//.GetByIdAsync(id: id);

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
        public async Task<ActionResult<ViewModels.ProductActivityPlanViewModel>> PostAsync(ViewModels.ProductActivityPlanViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.ProductActivityPlan
                    {
                        ForecastProduction = entity.ForecastProduction,
                        ForecastSales = entity.ForecastSales,
                        SalePerProductUnit = entity.SalePerProductUnit,
                        PercentageOfSalesShare = entity.PercentageOfSalesShare,
                        ProductId = entity.ProductSelectViewModel.Id,
                        ActivityPlanId = entity.ActivityPlanTitel.Id,
                    };

                await UnitOfWork.ProductActivityPlanRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.ProductActivityPlanViewModel>> PutAsync(ViewModels.ProductActivityPlanViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.ProductActivityPlanRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.ForecastProduction = entity.ForecastProduction;
                EditEntity.ForecastSales = entity.ForecastSales;
                EditEntity.SalePerProductUnit = entity.SalePerProductUnit;
                EditEntity.ProductId = entity.ProductSelectViewModel.Id;
                EditEntity.ActivityPlanId = entity.ActivityPlanTitel.Id;

                await UnitOfWork.ProductActivityPlanRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.ProductActivityPlan entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.ProductActivityPlanRepository.DeleteAsync(entity);
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
                await UnitOfWork.ProductActivityPlanRepository.DeleteByIdAsync(id: id);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpGet("ProductActivityPlanIndexByActivityPlanId/{ActivityPlanId}")]
        public async Task<ActionResult<IEnumerable<ViewModels.ProductActivityPlanViewModel>>> GetProductActivityPlanIndexByActivityPlanId(Guid activityPlanId)
        {
            try
            {
                var result =
                    await UnitOfWork.ProductActivityPlanRepository.GetProductActivityPlanIndexByActivityPlanIdAsync(activityPlanId);

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

        [HttpGet("ProductActivityPlanByActivityPlanId/{ActivityPlanId}")]
        public async Task<ActionResult<ViewModels.ProductActivityPlanViewModel>> GetProductActivityPlanByActivityPlanId(Guid activityPlanId)
        {
            try
            {
                ViewModels.ProductActivityPlanViewModel result =
                    new ViewModels.ProductActivityPlanViewModel();

                var ActivityPlanTitel =
                    await UnitOfWork.ActivityPlanRepository.GetActivityPlanTitelById(activityPlanId);

                result.ActivityPlanTitel = ActivityPlanTitel;

                //var result =
                //    await UnitOfWork.ProductActivityPlanRepository.GetProductActivityPlanByActivityPlanIdAsync(activityPlanId);

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
