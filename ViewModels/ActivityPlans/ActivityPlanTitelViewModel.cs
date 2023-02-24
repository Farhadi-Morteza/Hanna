

namespace ViewModels
{
    public class ActivityPlanTitelViewModel
    {
        public Guid Id { get; set; }
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


    }
}
