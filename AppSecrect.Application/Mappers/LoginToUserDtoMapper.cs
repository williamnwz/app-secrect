using AppSecrect.Application.Dtos;
using AppSecrect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.Application.Mappers
{
    public class LoginToUserDtoMapper : IDtoMapper<User, LoginDto>
    {
        public User Convert(LoginDto source)
        {
            return new User(source.Login, "", source.Password);
        }
    }
}
