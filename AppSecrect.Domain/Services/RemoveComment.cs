namespace AppSecrect.Domain.Services
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Exceptions;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System;
    using System.Threading.Tasks;

    public class RemoveComment : IRemoveComment
    {
        private readonly ICommentRepository commentRepository;
        private readonly IUserRepository userRepository;

        public RemoveComment(ICommentRepository commentRepository, IUserRepository userRepository)
        {
            this.commentRepository = commentRepository;
            this.userRepository = userRepository;
        }

        public async Task Remove(Comment comment)
        {
            Comment comentToRemove = await this.commentRepository.GetByIdAsync(comment.Id);

            if (comentToRemove == null)
                throw new DomainException("comment not exists");


        }
    }
}
