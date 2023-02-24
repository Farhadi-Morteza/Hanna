
namespace ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ViewModels.CompanySelectViewModel Company { get; set; }
        public bool Admin { get; set; } = false;
        public string FullName { get; set; } = String.Empty;
    }
}
