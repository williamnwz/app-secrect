using AppSecrect.Application.Dtos;
using AppSecrect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.Application.Mappers
{
    public class UserToLoginResponseMapper : IDtoMapper<LoginResponse, User>
    {
        public LoginResponse Convert(User source)
        {
            return new LoginResponse()
            {
                LoginAlias = source.Login.Anonimo()
            };
        }
    }
}
