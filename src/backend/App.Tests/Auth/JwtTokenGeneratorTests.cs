using App.Services.Auth;
using Appointments.App.Services;
using Appointments.Domain.Entities;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Appointments.App.Tests.Auth
{
    public class JwtTokenGeneratorTests
    {
        private AuthService? _authService;
        private Mock<IAuthService> _authServiceMock;

        public JwtTokenGeneratorTests()
        {
            _authServiceMock = new Mock<IAuthService>();
            _authService = _authServiceMock.Object as AuthService;
        }

        [Fact]
        public void CanGenerateJwtToken()
        {
            // Arrange
            var user = new User { Name = "fredy", Password = "password123" };

            // Act
            var token = _authService.GenerateToken(user);

            // Assert
            Assert.NotNull(token);
        }

        [Fact]
        public void TokenContainsExpectedClaims()
        {
            // Arrange
            var user = new User { Name = "fredy", Email = "fredy@example.com" };

            // Act
            var token = _authService.GenerateToken(user);

            // Assert
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            Assert.Contains(claims, c => c.Type == ClaimTypes.Name && c.Value == "fredy");
            Assert.Contains(claims, c => c.Type == ClaimTypes.Email && c.Value == "fredy@example.com");
        }

    }
}
