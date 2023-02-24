
namespace Models
{
    public class Employee : ExtraExtendedEntityBase
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public Employee Manager { get; set; }
        public Guid? ManagerId { get; set; }
        public List<Employee> Reports { get; set; }
    }
}
