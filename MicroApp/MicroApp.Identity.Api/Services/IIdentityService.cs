using MicroApp.Common.Authentication;
using MicroApp.Identity.Api.Domain;
using System;
using System.Threading.Tasks;

namespace MicroApp.Identity.Api.Services
{
    public interface IIdentityService
    {
        Task SignUpAsync(Guid id, string email, string password, string role = Role.User);
        Task<JsonWebToken> SignInAsync(string email, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
    }
}
