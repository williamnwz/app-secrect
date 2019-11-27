using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.Application.Dtos
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public string LoginAlias { get; set; }
    }
}
