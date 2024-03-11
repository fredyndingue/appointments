namespace Appointments.Domain.Models
{
    public class SignUpModel
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public List<string>? Roles { get; set; }
    }
}
