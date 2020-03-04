using MicroApp.Identity.Api.Domain;
using System;
using System.Threading.Tasks;

namespace MicroApp.Identity.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
