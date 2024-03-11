using Appointments.Domain.Entities;

namespace Appointments.App.Services
{
    public interface IUserService
    {
        public Task<User> SignIn(User signinUser);
        public Task<User> SignUp(User signupUser);
    }
}
