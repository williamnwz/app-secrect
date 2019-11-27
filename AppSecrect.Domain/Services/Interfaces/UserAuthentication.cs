using AppSecrect.CrossCutting.Security.Interfaces;
using AppSecrect.Domain.Entities;
using AppSecrect.Domain.Exceptions;
using AppSecrect.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Domain.Services.Interfaces
{
    public class UserAuthentication : IUserAuthentication
    {
        private readonly ITokenService tokenService;
        private readonly IUserRepository userRepository;

        public UserAuthentication(
            ITokenService tokenService,
            IUserRepository userRepository)
        {
            this.tokenService = tokenService;
            this.userRepository = userRepository;
        }

        public async Task<string> Authenticate(User user)
        {
            List<User> users = await this.userRepository.FindAsync(x => x.Login.Value == user.Login.Value);

            user.Password.Encrypt();
            if (users == null || !users.Any(x => x.Password.Value == user.Password.Value))
                throw new DomainException("Invalid User");

            User logedUser = users.FirstOrDefault();

            string token = await this.tokenService.GenerateToken(logedUser.Id, logedUser.Login.Value, new string[] { });

            return token;
        }
    }
}
