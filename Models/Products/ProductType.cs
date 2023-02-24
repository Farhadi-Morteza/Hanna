
namespace Models
{
    public class ProductType : EntityBase
    {
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ProductType))]

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
        public int? CultrueId { get; set; }

        public Culture? Culture { get; set; }
        //=================================================================================================
        //=================================================================================================
        public System.Collections.Generic.ICollection<Product> Products { get; set; }

    }
}
