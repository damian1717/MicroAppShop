using MicroApp.Common.Authentication;
using MicroApp.Common.RabbitMq;
using MicroApp.Identity.Api.Domain;
using MicroApp.Identity.Api.Repositories;
using MicroApp.Identity.Api.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Identity.Api.Tests.Services
{
    public class IdentityServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IPasswordHasher<User>> _passwordHasher;
        private readonly Mock<IJwtHandler> _jwtHandler;
        private readonly Mock<IRefreshTokenRepository> _refreshTokenRepository;
        private readonly Mock<IClaimsProvider> _claimsProvider;
        private readonly Mock<IBusPublisher> _busPublisher;
        private readonly IdentityService _identityService;
        public IdentityServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _passwordHasher = new Mock<IPasswordHasher<User>>();
            _jwtHandler = new Mock<IJwtHandler>();
            _refreshTokenRepository = new Mock<IRefreshTokenRepository>();
            _claimsProvider = new Mock<IClaimsProvider>();
            _busPublisher = new Mock<IBusPublisher>();
            _identityService = new IdentityService(_userRepository.Object, _passwordHasher.Object, _jwtHandler.Object, _refreshTokenRepository.Object, _claimsProvider.Object, _busPublisher.Object);
        }

        [Fact]
        public async Task signUpAsync_return_valid_result_when_request_valid()
        {
            //Arange
            _userRepository.Setup(s => s.GetAsync(Guid.NewGuid()))
                .Returns(Task.FromResult(new User(Guid.NewGuid(), "test@test.com", "user")));

            //Act
            await _identityService.SignUpAsync(Guid.NewGuid(), "test@test.com", "password", "user");

            //Assert
            _userRepository.Verify();
        }
    }
}
