using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroApp.Identity.Api.Services
{
    public interface IClaimsProvider
    {
        Task<IDictionary<string, string>> GetAsync(Guid userId);
    }
}
