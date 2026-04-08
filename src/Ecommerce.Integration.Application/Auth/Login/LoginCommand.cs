using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Auth.Login
{
    public record LoginCommand(string Username, string Password);
}
