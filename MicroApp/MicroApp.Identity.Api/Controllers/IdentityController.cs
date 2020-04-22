using MicroApp.Common.Authentication;
using MicroApp.Common.Mvc;
using MicroApp.Identity.Api.Dto;
using MicroApp.Identity.Api.Messages.Commands;
using MicroApp.Identity.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MicroApp.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet("GetUserByIdAsync/{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync([FromRoute] Guid id)
            => Ok(await _identityService.GetUserByIdAsync(id));

        [HttpGet("me")]
        [JwtAuth]
        public IActionResult Get() => Content($"Your id: '{UserId:N}'.");

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            command.BindId(c => c.Id);
            await _identityService.SignUpAsync(command.Id,
                command.Email, command.Password, command.Role);

            return NoContent();
        }

        
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignIn command)
            => Ok(await _identityService.SignInAsync(command.Email, command.Password));

        [HttpPut("me/password")]
        [JwtAuth]
        public async Task<ActionResult> ChangePassword(ChangePassword command)
        {
            await _identityService.ChangePasswordAsync(command.UserId,
                command.CurrentPassword, command.NewPassword);

            return NoContent();
        }
    }
}