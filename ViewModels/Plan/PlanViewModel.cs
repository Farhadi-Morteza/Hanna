

using Models;

namespace ViewModels
{
    public class PlanViewModel
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
            Name = nameof(Resources.DataDictionary.Title))]

        [System.ComponentModel.DataAnnotations.MaxLength(
            Constant.Length.LARGE_STRING,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Titel { get; set; } = string.Empty;
        //=================================================================================================
        //=================================================================================================
        public bool PlanCheckout { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool FinalApproval { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool PlanApproval { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool BreakCheckout { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool BreakApproval { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        public bool SavedLastTime { get; set; } = false;
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Company))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public ViewModels.CompanySelectViewModel Company { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Year))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public ViewModels.YearSelectViewModel Year { get; set; }
        //=================================================================================================
        //=================================================================================================
    }
}
