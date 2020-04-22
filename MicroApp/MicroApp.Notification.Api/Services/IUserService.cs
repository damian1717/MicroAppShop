using MicroApp.Notification.Api.Dto;
using RestEase;
using System;
using System.Threading.Tasks;

namespace MicroApp.Notification.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IUserService
    {
        [AllowAnyStatusCode]
        [Get("api/identity/GetUserByIdAsync/{id}")]
        Task<UserDto> GetUserByIdAsync([Path] Guid id);
    }
}
