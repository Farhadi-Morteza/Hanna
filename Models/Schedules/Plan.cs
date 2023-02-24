
namespace Models
{
    public class Plan : ExtendedEntityBase
    {
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Title))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            Constant.Length.LARGE_STRING,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Titel { get; set; } = string.Empty;
        
        //=================================================================================================
        //=================================================================================================
        public bool PlanCheckout { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool FinalApproval { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool PlanApproval { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool BreakCheckout { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool BreakApproval { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //=================================================================================================
        //=================================================================================================
        public Guid YearId { get; set; }
        public virtual Year Year { get; set; }
        //=================================================================================================
        //=================================================================================================
        public List<Models.ActivityPlan> ActivityPlans { get; set; } =
            new List<Models.ActivityPlan>();
        //=================================================================================================
        //=================================================================================================


    }
}
