
namespace ViewModels
{
    public class ProductViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]

        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Id))]
        public System.Guid Id { get; set; }
        //=================================================================================================

        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Activity))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Name { get; set; }
        //=================================================================================================

        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
        //=================================================================================================
        //[System.ComponentModel.DataAnnotations.Required(
        //    AllowEmptyStrings = false,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        //public System.Guid ProductTypeId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public ViewModels.ProductTypeSelectViewModel ProductType { get; set; }
        //=================================================================================================
        //=================================================================================================
        //[System.ComponentModel.DataAnnotations.Required(
        //    AllowEmptyStrings = false,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        //public System.Guid ActivityId { get; set; }

        //[System.ComponentModel.DataAnnotations.Required(
        //    AllowEmptyStrings = false,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        //public ViewModels.ActivitySelectViewModel Activity { get; set; }
        //=================================================================================================
        //=================================================================================================
        //[System.ComponentModel.DataAnnotations.Required(
        //    AllowEmptyStrings = false,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        //public System.Guid ProductIndicatorId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public ViewModels.ProductIndicatorSelectViewModel ProductIndicator { get; set; }
        //=================================================================================================
    }
}
