using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Business : ExtraExtendedEntityBase
    {
        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Business))]

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
        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Business))]

        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public Guid PrincipalBusinessId { get; set; }


        [System.ComponentModel.DataAnnotations.Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        //[System.Text.Json.Serialization.JsonIgnore]
        public virtual Models.PrincipalBusiness PrincipalBusiness { get; set; }
        //=================================================================================================
        //=================================================================================================
        public IList<Activity>? Activities { get; set; }
    }
}
