
namespace Models
{
    public class CompanyType : ExtendedEntityBase
    {
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.CompanyType))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            Constant.Length.GENERAL_NAME,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Required
            (ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Name { get; set; } = string.Empty;

        //=================================================================================================
        //=================================================================================================
        //public int CultrueId { get; set; }
        //public Culture Culture { get; set; }
        //=================================================================================================
        //=================================================================================================
        //public List<Company> Companies { get; set; } = new List<Company>();
    }
}
