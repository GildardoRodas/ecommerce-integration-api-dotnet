using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Auth.Login
{
    public class LoginHandler
    {

        private readonly IJwtTokenGenerator _jwt;

        public LoginHandler(IJwtTokenGenerator jwt)
        {
            _jwt = jwt;
        }

        public LoginResult Handle(LoginCommand command)
        {
            // DEMO: usuario hardcodeado
            if (command.Username != "admin" || command.Password != "admin123")
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _jwt.GenerateToken("1", command.Username);
            return new LoginResult(token);
        }

    }
}
