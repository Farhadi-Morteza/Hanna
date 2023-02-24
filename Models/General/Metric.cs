
namespace Models
{
    public class Metric : ExtraExtendedEntityBase
    {
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Business))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            Constant.Length.GENERAL_NAME,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string? Name { get; set; }

        //=================================================================================================

        private IList<ActivityIndicator>? _activityIndicators;
        public IList<ActivityIndicator> ActivityIndicators
        {
            get
            {
                if (_activityIndicators == null)
                {
                    _activityIndicators =
                        new List<ActivityIndicator>();
                }
               return _activityIndicators;
            }
        }
        //public ICollection<ActivityIndicator> ActivityIndicators { get; set; }

        //=================================================================================================
        public ICollection<ProductIndicator> ProductIndicators { get; set; }
    }
}
