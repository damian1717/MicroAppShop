using System;

namespace MicroApp.Notification.Api.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
