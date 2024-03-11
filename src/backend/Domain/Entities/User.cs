namespace Appointments.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<string>? Roles { get; set; }
        public bool IsActive { get; set; }
        public string? Token { get; set; }

        public User(string name, String email, string password, List<string>? roles)
        {
            Name = name;
            Email = email;
            Password = password;
            Roles = roles;
        }

    }
}
