
namespace ViewModels
{
    public class ProductActivityPlanViewModel
    {

        [System.ComponentModel.DataAnnotations.Key]

        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Id))]
        public Guid Id { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ForecastFinalPrice))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public double ForecastProduction { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ForecastFinalPrice))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public double ForecastSales { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ForecastFinalPrice))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public double SalePerProductUnit { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ForecastFinalPrice))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]

        public double ForecastIncom => ForecastSales * SalePerProductUnit;
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ForecastFinalPrice))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public double PercentageOfSalesShare { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

        public ViewModels.ProductSelectViewModel ProductSelectViewModel { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public Guid ActivityPlanId { get; set; }

        public ViewModels.ActivityPlanTitelViewModel ActivityPlanTitel { get; set; } =
            new ActivityPlanTitelViewModel();
        //=================================================================================================
        //=================================================================================================
    }
}
