using MicroApp.Identity.Api.Domain;
using System.Threading.Tasks;

namespace MicroApp.Identity.Api.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}
