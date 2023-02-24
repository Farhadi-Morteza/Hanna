
namespace ViewModels
{
    public class ActivityViewModel
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
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public ViewModels.BusinessSelectViewModel Business { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public ViewModels.ActivityIndicatorSelectViewModel ActivityIndicator{ get; set; }
        //=================================================================================================
        //=================================================================================================
        public List<Models.Product> Products { get; set; } = new List<Models.Product>();
        //=================================================================================================
    }
}
