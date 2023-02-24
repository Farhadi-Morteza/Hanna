using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PlanActivityIndexViewModel
    {
        public Guid PlanId { get; set; }
        public Guid ActivityPlanId { get; set; }
        //=================================================================================================
        //=================================================================================================
        public string PlanTitel { get; set; } = string.Empty;
        public string CompanyPartName { get; set; } = string.Empty;
        public string YearName { get; set; } = string.Empty;
        //public string PrincipalBusiness { get; set; } = string.Empty;
        //public string Business { get; set; } = string.Empty;
        //public string Activity { get; set; } = string.Empty;
        public List<Models.ActivityPlan> ActivityPlans { get; set; } 
        //public List<ViewModels.ProductSelectViewModel> Products { get; set; } = new List<ProductSelectViewModel>();
        //public string BusinessType { get; set; } = string.Empty;
    }
}
