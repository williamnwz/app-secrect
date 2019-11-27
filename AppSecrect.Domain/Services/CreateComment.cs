namespace AppSecrect.Domain.Services
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Exceptions;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public class CreateComment : ICreateComment
    {
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;
        public CreateComment(
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }

        public async Task Comment(Comment comment)
        {
            if (!comment.Description.IsValid())
                throw new DomainException("Description's post isn't valid!");

            Post post = await this.postRepository.GetByIdAsync(comment.PostId);

            if (post == null)
                throw new DomainException("Post not exists!");

            User user = await this.userRepository.GetByIdAsync(comment.ResponsableId);

            if (user == null)
                throw new DomainException("Responsable not exists!");

            post.IncludeComment(comment);

            await postRepository.SaveAsync(post);

        }
    }
}
