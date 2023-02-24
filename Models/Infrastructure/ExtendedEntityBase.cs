

namespace Models
{
    public abstract class ExtendedEntityBase : EntityBase
    {
        public ExtendedEntityBase() : base()
        {

        }

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            AutoGenerateField = false,
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsDeleted))]
        //[System.Text.Json.Serialization.JsonIgnore]
        public bool IsDeleted { get; set; }
        //=================================================================================================

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            AutoGenerateField = false)]
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid? DeleteUserId { get; set; }
        //=================================================================================================

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            AutoGenerateField = false,
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.DeleteDate))]
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? DeleteDate { get; set; }
        //=================================================================================================

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(AutoGenerateField = false)]
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid? InsertUserId { get; set; }
        //=================================================================================================

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            AutoGenerateField = false,
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.InsertDate))]

        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? InsertDate { get; set; } = null!;
        //=================================================================================================

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(AutoGenerateField = false)]
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid? UpdateUserId { get; set; }
        //=================================================================================================

        //=================================================================================================
        [System.ComponentModel.DataAnnotations.Display(
            AutoGenerateField = false,
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.UpdateDate))]
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? UpdateDate { get; set; }
        //=================================================================================================

        //=================================================================================================

    }
}
