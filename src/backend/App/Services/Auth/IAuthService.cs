using Appointments.Domain.Entities;

namespace Appointments.App.Services
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}
