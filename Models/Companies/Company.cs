
namespace Models
{
    public class Company : ExtendedEntityBase
    {
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Company))]

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
        //[System.ComponentModel.DataAnnotations.Display(
        //    ResourceType = typeof(Resources.DataDictionary),
        //    Name = nameof(Resources.DataDictionary.EconomicCode))]

        //[System.ComponentModel.DataAnnotations.MaxLength(
        //    Constant.Length.ECONOMIC_CODE,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        //public string EconomicCode { get; set; } = string.Empty;
        //=================================================================================================
        //[System.ComponentModel.DataAnnotations.Display(
        //    ResourceType = typeof(Resources.DataDictionary),
        //    Name = nameof(Resources.DataDictionary.RegistrationNumber))]

        //[System.ComponentModel.DataAnnotations.MaxLength(
        //    Constant.Length.REGISTRATION_NUMBER,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        //public string RegistrationNumber { get; set; } = string.Empty;
        //=================================================================================================
        //[System.ComponentModel.DataAnnotations.Display(
        //    ResourceType = typeof(Resources.DataDictionary),
        //    Name = nameof(Resources.DataDictionary.NationalCode))]

        //[System.ComponentModel.DataAnnotations.MaxLength(
        //    Constant.Length.NATIONAL_CODE,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        //public string NatinalCode { get; set; } = string.Empty;
        //=================================================================================================
        //public byte[]? Logo { get; set; } = null;

        //=================================================================================================
        //=================================================================================================
        public Company? CompanyParent { get; set; }

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Company))]
        public Guid? CompanyParentId { get; set; } = null;
        public List<Company>? CompanyChild { get; set; }
        //=================================================================================================
        //=================================================================================================
        //[System.ComponentModel.DataAnnotations.Display(
        //    ResourceType = typeof(Resources.DataDictionary),
        //    Name = nameof(Resources.DataDictionary.CompanyType))]

        //[System.ComponentModel.DataAnnotations.Required(
        //    AllowEmptyStrings = false,
        //    ErrorMessageResourceType = typeof(Resources.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        //public Guid CompanyTypeId { get; set; }
        //public CompanyType CompanyType { get; set; } = new CompanyType();
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.CompanyCategory))]

        [System.ComponentModel.DataAnnotations.Required
            (ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public Guid CompanyCategoryId { get; set; }
        public CompanyCategory CompanyCategory { get; set; } = new CompanyCategory();
        //=================================================================================================

        //public int? AddressId { get; set; }
        //public Address Address { get; set; }


        public List<User> Users { get; set; }

        //=================================================================================================
        //=================================================================================================
        public List<Plan> Plans { get; set; }
}
}
