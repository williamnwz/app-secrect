namespace AppSecrect.Domain.Services
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Exceptions;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System.Threading.Tasks;
    public class CreatePost : ICreatePost
    {
        private readonly IUserRepository userRepository;

        public CreatePost(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Create(User responsable, Post post)
        {
            if (responsable == null)
                throw new DomainException("Invalid responsable");

            User user = await this.userRepository.GetByIdAsync(responsable.Id);

            if (user == null)
                throw new DomainException("Invalid responsable");

            user.IncludePost(post);

           await userRepository.SaveAsync(user);
        }
    }
}
