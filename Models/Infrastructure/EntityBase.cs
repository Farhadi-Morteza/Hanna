

namespace Models
{
    public abstract class EntityBase : object
    {
        public EntityBase() : base()
        {
			Id = System.Guid.NewGuid();
        }

		// **********
		[System.ComponentModel.DataAnnotations.Key]

		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]

		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]
		public System.Guid Id { get; set; }
		// **********
	}
}
