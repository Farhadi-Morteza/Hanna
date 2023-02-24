using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Activity : ExtraExtendedEntityBase 
    {
        public Activity() : base()
        {
            Business =
                new Business();

            _activityPlan =
                new List<ActivityPlan>();
        }

        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Activity))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            Constant.Length.GENERAL_NAME,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Name { get; set; } = string.Empty;
        //=================================================================================================
        //=================================================================================================
        public System.Guid BusinessId { get; set; }
        public Business? Business { get; set; }
        //=================================================================================================
        //=================================================================================================
        public System.Guid ActivityIndicatorId { get; set; }
        public ActivityIndicator? ActivityIndicator { get; set; }
        //=================================================================================================
        //=================================================================================================
        public List<Product> Products { get; set; } =
            new List<Product>();
        //=================================================================================================
        //=================================================================================================
        //public IList<ActivityPlan>? ActivityPlans { get; set; }

        private System.Collections.Generic.List<ActivityPlan> _activityPlan;
        public IReadOnlyList<ActivityPlan> ActivityPlans
        {
            get
            {
                //if (_activityPlan == null)
                //{
                //    _activityPlan = 
                //        new System.Collections.Generic.List<ActivityPlan>();
                //}
                //return _activityPlan;
                return _activityPlan.AsReadOnly();
            }
        }
    }
}
