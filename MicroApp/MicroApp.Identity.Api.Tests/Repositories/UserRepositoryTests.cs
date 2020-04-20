using MicroApp.Common.Mongo;
using MicroApp.Identity.Api.Domain;
using MicroApp.Identity.Api.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Identity.Api.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly IUserRepository _repository;
        private Guid _guid;
        private User _user;
        private Mock<IMongoRepository<User>> _mockMongoRepository;
        public UserRepositoryTests()
        {
            _guid = Guid.NewGuid();
            _user = new User(_guid, "test@test.com", "user");
            _mockMongoRepository = new Mock<IMongoRepository<User>>();
            _repository = new UserRepository(_mockMongoRepository.Object);
        }

        [Fact]
        public async Task getasync_return_valid_result_when_request_valid()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_user);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(_guid), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(_guid, result.Id);
            Assert.Equal(_user.Email, result.Email);
            Assert.Equal(_user.Role, result.Role);
        }

        [Fact]
        public async Task getasync_return_once_time()
        {
            //Arange
            _mockMongoRepository.Setup(s => s.GetAsync(_guid)).ReturnsAsync(_user);

            //Act
            var result = await _repository.GetAsync(_guid);

            //Assert
            _mockMongoRepository.Verify(r => r.GetAsync(_guid), Times.Once);
        }

        [Fact]
        public async Task addasync_invoke_once_time()
        {
            //Arrange 
            _mockMongoRepository.Setup(s => s.AddAsync(_user)).Returns(Task.CompletedTask);

            //Act
            await _repository.AddAsync(_user);

            //Assert
            _mockMongoRepository.Verify(r => r.AddAsync(_user), Times.Once);
        }

        [Fact]
        public async Task updateasync_invoke_once_time()
        {
            //Arrange 
            _mockMongoRepository.Setup(s => s.UpdateAsync(_user)).Returns(Task.CompletedTask);

            //Act
            await _repository.UpdateAsync(_user);

            //Assert
            _mockMongoRepository.Verify(r => r.UpdateAsync(_user), Times.Once);
        }
    }
}
