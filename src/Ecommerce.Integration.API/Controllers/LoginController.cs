using Ecommerce.Integration.Application.Auth.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Integration.API.Controllers
{

    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {

        private readonly LoginHandler _handler;

        public LoginController(LoginHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginCommand command)
        {
            try
            {
                return Ok(_handler.Handle(command));
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

    }
}
