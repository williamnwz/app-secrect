
namespace AppSecrect.Application.Mappers
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Domain.Entities;
    using System;

    /// <summary>
    /// RegisterUserToUserMapper
    /// </summary>
    public class RegisterUserToUserMapper : IDtoMapper<User, CreateUser>
    {
        public User Convert(CreateUser source)
        {
            return new User(source.Login, source.Email, source.Password);
        }
    }
}
