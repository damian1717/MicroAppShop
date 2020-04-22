using System;

namespace MicroApp.Identity.Api.Dto
{
    public class UserDto
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
    }
}
