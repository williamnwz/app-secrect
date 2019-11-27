
namespace AppSecrect.Domain.Services
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Exceptions;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    /// <summary>
    /// CreateUser
    /// </summary>
    public class SaveUser : ISaveUser
    {
        private readonly IUserRepository userRepository;

        public SaveUser(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task SaveUserAsync(User user)
        {
            if (!user.Email.IsValid())
                throw new DomainException("Invalid Email");

            if (!user.Login.IsValid())
                throw new DomainException("Invalid Login");

            if (!user.Password.IsValid())
                throw new DomainException("Invalid Password");

            Func<User, bool> userValidToCreate = (User u) =>
            {
                return u.Login.Value.Equals(user.Login.Value, StringComparison.InvariantCultureIgnoreCase);
            };

            List<User> users = await userRepository.FindAsync(userValidToCreate);

            if (users.Any())
                throw new DomainException("login already exist");

            if (users.Any(u => u.Email.Value.Equals(user.Email.Value, StringComparison.InvariantCultureIgnoreCase)))
                throw new DomainException("Email already exist");

            user.Password.Encrypt();

            await this.userRepository.SaveAsync(user);
        }
    }
}
