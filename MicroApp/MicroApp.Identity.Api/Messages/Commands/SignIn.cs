using Newtonsoft.Json;

namespace MicroApp.Identity.Api.Messages.Commands
{
    public class SignIn
    {
        public string Email { get; }
        public string Password { get; }

        [JsonConstructor]
        public SignIn(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
