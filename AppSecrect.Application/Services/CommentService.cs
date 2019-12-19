using AppSecrect.Application.Dtos.Comments;
using AppSecrect.Application.Services.Interfaces;
using AppSecrect.Domain.Entities;
using AppSecrect.Domain.Repositories;
using AppSecrect.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICreateComment createComment;
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnityOfWork unityOfWork;
        public CommentService(
            ICreateComment createComment,
            IPostRepository postRepository,
            IUserRepository userRepository,
            IUnityOfWork unityOfWork)
        {
            this.createComment = createComment;
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.unityOfWork = unityOfWork;
        }

        public async Task<CreateCommentReponse> CreateComment(Guid responsableId, Guid postId, string description, string alias, string colorProfileUsed)
        {
            Post post = await postRepository.GetByIdAsync(postId);

            if (post == null)
                throw new ApplicationException("Post not exists!");

            User responsable = await userRepository.GetByIdAsync(responsableId);
            if (responsable == null)
                throw new ApplicationException("responsable not exits!");

            Comment comment = new Comment(post, responsable, description, alias, colorProfileUsed);

            await createComment.Comment(comment);

            await this.unityOfWork.Commit();

            return new CreateCommentReponse()
            {
                Create = comment.Create,
                ResponsableId = comment.ResponsableId,
                Description = comment.Description.Value
            };
        }
    }
}
