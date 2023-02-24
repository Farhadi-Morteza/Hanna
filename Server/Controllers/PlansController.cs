using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    public class PlansController : Infrastructure.ApiControllerWithDatabaseBase
    {
        public PlansController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.PlanViewModel>>> GetAsync()
        {
            try
            {
                var result =
                    await UnitOfWork.CompanyRepository.GetRecursiveAsync(id: CompanyId);


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

        [HttpGet(template: nameof(Resources.ActionRoute.SuggestedPlan))]
        public async Task<ActionResult<IEnumerable<ViewModels.PlanViewModel>>> GetSuggestedPlanAsync()
        {
            try
            {
                var Companies =
                    await CompaniesRelatedOfUser;

                var plans =
                    await UnitOfWork.PlanRepository.GetSuggestedPlanAsync();

                var result =
                    (from c in Companies join p in plans on c.Id equals p.Company.Id select p).ToList();

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

        [HttpGet(template: nameof(Resources.ActionRoute.CheckoutPlan))]
        public async Task<ActionResult<IEnumerable<ViewModels.PlanViewModel>>> GetCheckoutPlanAsync()
        {
            try
            {
                var Companies =
                    await CompaniesRelatedOfUser;

                var plans =
                    await UnitOfWork.PlanRepository.GetCheckoutPlanAsync();

                var result =
                    (from c in Companies join p in plans on c.Id equals p.Company.Id select p).ToList();

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

        [HttpGet("PlanActiviyIndex/{Id}")]
        public async Task<ActionResult<Models.Plan>> GetPlanActivityIndexAsync(Guid id)
        {
            try
            {
                //Guid id = Guid.Parse("a4f7b901-dd3c-4b78-a4d3-4fdd95ba0bc7");
                var result =
                    await UnitOfWork.PlanRepository.GetPlanActivityIndexByPlanIdAsync(id);

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
        public async Task<ActionResult<ViewModels.PlanViewModel>> GetAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.PlanRepository.GetIndexByIdAsync(id: id);

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
        public async Task<ActionResult<ViewModels.PlanTitelViewModel>> GetTitelByIdAsync(Guid id)
        {
            try
            {
                var result =
                       await UnitOfWork.PlanRepository.GetPlanTitelByIdAsync(id: id);

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
        public async Task<ActionResult<ViewModels.PlanViewModel>> PostAsync(ViewModels.PlanViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            bool SavedLastTime =
                 await UnitOfWork.PlanRepository.SavedLastTime(entity.Company.Id, entity.Year.Id);

            try
            {
                var NewEntity =
                    new Models.Plan
                    {
                        Titel = entity.Titel,
                        FinalApproval = entity.FinalApproval,
                        PlanApproval = entity.PlanApproval,
                        BreakApproval = entity.BreakApproval,
                        CompanyId = entity.Company.Id,
                        YearId = entity.Year.Id,
                    };

                if(SavedLastTime == false)
                {
                    await UnitOfWork.PlanRepository.InsertAsync(NewEntity);
                    await UnitOfWork.SaveAsync();
                }

                entity.Id = NewEntity.Id;
                entity.SavedLastTime = SavedLastTime;
                return Ok(value: entity);                
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPost("All")]
        public async Task<ActionResult<bool>> PostAllAsync(bool nextYear, bool thisYear)
        {
            bool returlResult =
                false;

            var parts =
                await UnitOfWork.CompanyRepository.GetSelectAsync(Data.Tools.Enums.CompanyCategories.Part);

            //var pp = UserId;

            if (parts == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
            int yearName;

            if (nextYear)
            {
                yearName =
                    persianCalendar.GetYear(DateTime.UtcNow.AddYears(1));
            }
            else
            {
                yearName =
                    persianCalendar.GetYear(DateTime.UtcNow);
            }

            var year =
                await UnitOfWork.YearRepository.GetYearByYearName(yearName);

            if (year == null)
            {
                Models.Year newYear =
                    new Models.Year()
                    {
                        Name = yearName,
                    };
            
                await UnitOfWork.YearRepository.InsertAsync(newYear);
                await UnitOfWork.SaveAsync();

                ViewModels.YearViewModel mm = new ViewModels.YearViewModel();
                mm.Name = newYear.Name;
                mm.Id = newYear.Id;

                year = mm;
            }

           
            try
            {
                foreach (var part in parts)
                {
                    bool SavedLastTime =
                         await UnitOfWork.PlanRepository.SavedLastTime(part.Id, year.Id );

                    if (SavedLastTime == false)
                    {
                        var NewEntity =
                            new Models.Plan
                            {
                                Titel = $"برنامه {part.Name} سال {year.Name}",
                                FinalApproval = false,
                                PlanApproval = false,
                                BreakApproval = false,
                                CompanyId = part.Id,
                                YearId = year.Id,
                            };

                        await UnitOfWork.PlanRepository.InsertAsync(NewEntity);
                        await UnitOfWork.SaveAsync();

                        returlResult = true;
                    }                    
                }
                return Ok(returlResult);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ViewModels.PlanViewModel>> PutAsync(ViewModels.PlanViewModel entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.PlanRepository.GetByIdAsync(entity.Id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.Titel = entity.Titel;
                EditEntity.FinalApproval = entity.FinalApproval;
                EditEntity.PlanApproval = entity.PlanApproval;
                EditEntity.BreakApproval = entity.BreakApproval;
                EditEntity.CompanyId = entity.Company.Id;
                EditEntity.YearId = entity.Year.Id;

                await UnitOfWork.PlanRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: entity);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut("PlanCheckout/{id}")]
        public async Task<ActionResult<ViewModels.PlanViewModel>> PutPlanCheckoutAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.PlanRepository.GetByIdAsync(id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.PlanCheckout = true;

                await UnitOfWork.PlanRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut("RejectPlanCheckout/{id}")]
        public async Task<ActionResult<ViewModels.PlanViewModel>> PutRejectPlanCheckoutAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.PlanRepository.GetByIdAsync(id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.PlanCheckout = false;

                await UnitOfWork.PlanRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut("PlanApproval/{id}")]
        public async Task<ActionResult<ViewModels.PlanViewModel>> PutPlanApprovalAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.PlanRepository.GetByIdAsync(id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.PlanCheckout = true;
                EditEntity.PlanApproval = true;

                await UnitOfWork.PlanRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpPut("RejectPlanApproval/{id}")]
        public async Task<ActionResult<ViewModels.PlanViewModel>> PutRejectPlanApprovalAsync(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                var EditEntity =
                    await UnitOfWork.PlanRepository.GetByIdAsync(id);

                if (EditEntity == null)
                    return NotFound(Resources.InformationMessages.NotFount);

                EditEntity.PlanApproval = false;

                await UnitOfWork.PlanRepository.UpdateAsync(EditEntity);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);

            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync(Models.Plan entity)
        {
            if (entity == null)
                return BadRequest(Resources.InformationMessages.BadRequest);

            try
            {
                await UnitOfWork.PlanRepository.DeleteAsync(entity);
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
                await UnitOfWork.PlanRepository.DeleteByIdAsync(id: id);
                await UnitOfWork.SaveAsync();

                return Ok(value: true);
            }
            catch (Exception)
            {
                return BadRequest(Resources.InformationMessages.BadRequest);
            }
        }

        [HttpGet("PlanActiviyPlan/{Id}")]
        public async Task<ActionResult<IEnumerable<ViewModels.PlanViewModel>>> GetAllAsync(Guid id)
        {
            try
            {
                var result =
                    await UnitOfWork.PlanRepository.GetPlan_ActivityPlanByPlanIdAsync(id: id);//.GetIndexAsync();//.GetAllAsync();

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

