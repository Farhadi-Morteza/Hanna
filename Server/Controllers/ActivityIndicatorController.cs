using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    public class ActivityIndicatorController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public ActivityIndicatorController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.ActivityIndicatorViewModel>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ActivityIndicatorRepository.GetIndexAsync();

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
        public async Task<ActionResult<ViewModels.ActivityIndicatorViewModel>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.ActivityIndicatorRepository.GetIndexByIdAsync(id: id);

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
        public async Task<ActionResult<IEnumerable<ViewModels.ActivityIndicatorSelectViewModel>>> GetSelectAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.ActivityIndicatorRepository.GetSelectAsync();

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
        public async Task<ActionResult<ViewModels.ActivityIndicatorViewModel>> PostAsync(ViewModels.ActivityIndicatorViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var NewEntity =
                    new Models.ActivityIndicator
                    {
                        Name = entity.Name,
                        IsActive = entity.IsActive,
                        MetricId = entity.Metric.Id,
                    };

                await UnitOfWork.ActivityIndicatorRepository.InsertAsync(NewEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: NewEntity);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.ActivityIndicatorViewModel>> PutAsync(ViewModels.ActivityIndicatorViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.ActivityIndicatorRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Name = entity.Name;
                EditEntity.IsActive = entity.IsActive;
                EditEntity.MetricId = entity.Metric.Id;

                await UnitOfWork.ActivityIndicatorRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: EditEntity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.ActivityIndicator entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.ActivityIndicatorRepository.DeleteAsync(entity);
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
                await UnitOfWork.ActivityIndicatorRepository.DeleteByIdAsync(id: id);
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
