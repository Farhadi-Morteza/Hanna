
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    public class ActivityPlansController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public ActivityPlansController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ActivityPlan>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ActivityPlanRepository.GetAllAsync();

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
        public async Task<ActionResult<ViewModels.ActivityPlanViewModel>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.ActivityPlanRepository.GetActivityPlanByIdAsync(id); //.GetByIdAsync(id: id);

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

        [HttpGet("Titel/{Id}")]
        public async Task<ActionResult<ViewModels.ActivityPlanTitelViewModel>> GetTitelById(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.ActivityPlanRepository.GetActivityPlanTitelById(id); 

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
        public async Task<ActionResult<ViewModels.ActivityPlanViewModel>> PostAsync(ViewModels.ActivityPlanViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.ActivityPlan
                    {
                        ForecastFinalPrice = entity.ForecastFinalPrice,
                        ForecastLevel = entity.ForecastLevel,
                        Capacitylevel = entity.Capacitylevel,
                        PlanId = entity.PlanTitel.Id,
                        ActivityId = entity.ActivitySelectViewModel.Id,
                        BusinessTypeId = entity.BusinessType.Id,

                    };

                await UnitOfWork.ActivityPlanRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.ActivityPlanViewModel>> PutAsync(ViewModels.ActivityPlanViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.ActivityPlanRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.ForecastFinalPrice = entity.ForecastFinalPrice;
                EditEntity.ForecastLevel = entity.ForecastLevel;
                EditEntity.Capacitylevel = entity.Capacitylevel;
                EditEntity.PlanId = entity.PlanTitel.Id;
                EditEntity.ActivityId = entity.ActivitySelectViewModel.Id;
                EditEntity.BusinessTypeId = entity.BusinessType.Id;

                await UnitOfWork.ActivityPlanRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.ActivityPlan entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.ActivityPlanRepository.DeleteAsync(entity);
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
                await UnitOfWork.ActivityPlanRepository.DeleteByIdAsync(id: id);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }
        
        [HttpGet("ActivityPlanIndexByPlanId/{PlanID}")]
        public async Task<ActionResult<IEnumerable<ViewModels.ActivityPlanIndexViewModel>>> GetActivityPlanIndexByPlanIdAsync(Guid planId)
        {
            try
            {
                var result =
                    await UnitOfWork.ActivityPlanRepository.GetActivityPlanIndexByPlanIdAsync(planId);

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

        [HttpGet("ActivityPlanByPlanId/{PlanID}")]
        public async Task<ActionResult<ViewModels.ActivityPlanViewModel>> GetActivityPlanByPlanIdAsync(Guid planId)
        {
            try
            {
                ViewModels.ActivityPlanViewModel result =
                    new ViewModels.ActivityPlanViewModel();

                var PlanTitel =
                    await UnitOfWork.PlanRepository.GetPlanTitelByIdAsync(planId);
                
                result.PlanTitel = PlanTitel;

                //var result =
                //    await UnitOfWork.ActivityPlanRepository.GetActivityPlanByPlanIdAsync(planId);

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

        [HttpGet("Summary/{Id}")]
        public async Task<ActionResult<ViewModels.ActivityPlanSummaryViewModel>> GetSummary(Guid id)
        {
            try
            {
                //Guid id = Guid.Parse("4cab85d8-7965-4c2e-8187-a815c9653690");
                var result =
                    await UnitOfWork.ActivityPlanRepository.GetActivityPlanSummaryAsync(id);

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
