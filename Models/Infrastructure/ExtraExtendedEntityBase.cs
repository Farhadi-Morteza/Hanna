

namespace Models
{
    public abstract class ExtraExtendedEntityBase : ExtendedEntityBase
    {
        public ExtraExtendedEntityBase() : base()
        {
            IsActive = true;
        }

        [System.ComponentModel.DataAnnotations.Display(
            ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
    }
}
