
namespace Models
{
    public class Year : ExtendedEntityBase
    {

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Year))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public int? Name { get; set; } 

        //=================================================================================================
        public List<Plan> Plans { get; set; }
    }
}
