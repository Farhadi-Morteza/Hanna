
namespace ViewModels
{
    public class ActivityPlanSummaryViewModel
    {
        public Guid ActivityPlanId { get; set; }
        public Guid PlanId { get; set; }
        public Guid ActivityId { get; set; }
        public string PlanTitel { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public double ForecastFinalPrice { get; set; }
        public double ForecastLevel { get; set; }
        public double Capacitylevel { get; set; }
        public string PrincipalBusiness { get; set; } = string.Empty;
        public string Business { get; set; } = string.Empty;
        public string Activity { get; set; } = string.Empty;
        public string BusinessType { get; set; } = string.Empty;
        public string ActivityIndicator { get; set; } = string.Empty;
        public string ActivityIndicatorMetric { get; set; } = string.Empty;
        public string ProductIndicatorMetric { get; set; } = string.Empty;
        public List<ViewModels.ProductActivityPlanViewModel> ProductActivityPlans { get; set; } =
            new List<ProductActivityPlanViewModel>();
    }
}
