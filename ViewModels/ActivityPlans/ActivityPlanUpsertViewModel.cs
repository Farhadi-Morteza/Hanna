using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ActivityPlanUpsertViewModel
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
        [System.ComponentModel.DataAnnotations.Required(
              AllowEmptyStrings = false,
              ErrorMessageResourceType = typeof(Resources.ErrorMessages),
              ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public Guid PlanId { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
              ResourceType = typeof(Resources.DataDictionary),
              Name = nameof(Resources.DataDictionary.ForecastFinalPrice))]

        [System.ComponentModel.DataAnnotations.Required(
              AllowEmptyStrings = false,
              ErrorMessageResourceType = typeof(Resources.ErrorMessages),
              ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public double ForecastFinalPrice { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ForecastLevel))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public double ForecastLevel { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Capacitylevel))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public double Capacitylevel { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

        public ViewModels.ActivitySelectViewModel ActivitySelectViewModel { get; set; }
        //=================================================================================================
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public ViewModels.BusinessTypeSelectViewModel BusinessType { get; set; }
    }
}
