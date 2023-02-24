namespace Models
{
    public class Product : ExtraExtendedEntityBase 
    {

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Product))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            Constant.Length.GENERAL_NAME,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Name { get; set; }

        //=================================================================================================
        //=================================================================================================
        [System.Text.Json.Serialization.JsonIgnore]
        public List<Activity> Activities { get; set; }
        = new List<Activity>();
        //=================================================================================================
        //=================================================================================================
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        //=================================================================================================
        //=================================================================================================
        public System.Guid ProductIndicatorId { get; set; }
        public ProductIndicator ProductIndicator { get; set; }
        //=================================================================================================
        //public Guid ActivityId { get; set; }
        //public Activity Activity { get; set; }
    }
}
