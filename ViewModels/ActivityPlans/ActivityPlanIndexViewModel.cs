
namespace ViewModels
{
    public class ActivityPlanIndexViewModel
    {
        public Guid Id { get; set; }
        //=================================================================================================
        public Guid PlanId { get; set; }
        //=================================================================================================
        public string PrincipalBusiness { get; set; } = string.Empty;
        public string Business { get; set; } = string.Empty;
        public string Activity { get; set; } = string.Empty;
        public List<ViewModels.ProductActivityPlanViewModel> ProductActivityPlans { get; set; } =
            new List<ViewModels.ProductActivityPlanViewModel>();
        public string BusinessType { get; set; } = string.Empty;
        
        

    }
}
