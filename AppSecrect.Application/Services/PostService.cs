namespace AppSecrect.Application.Services
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Application.Dtos.Posts;
    using AppSecrect.Application.Services.Interfaces;
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PostService : IPostService
    {
        private readonly ICreatePost createPost;
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        private readonly IListPosts listPosts;
        private readonly IUnityOfWork unityOfWork;

        public PostService(
            ICreatePost createPost,
            IUserRepository userRepository,
            IPostRepository postRepository,
            IListPosts listPosts,
            IUnityOfWork unityOfWork)
        {
            this.createPost = createPost;
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.listPosts = listPosts;
            this.unityOfWork = unityOfWork;
        }
        public async Task<CreatePostResponse> CreatePost(Guid responsableId, string description)
        {
            User responsable = await this.userRepository.GetByIdAsync(responsableId);

            if (responsable == null)
                throw new ApplicationException("Invalid responsable");

            Post newPost = new Post(responsable, description);

            await this.createPost.Create(responsable, newPost);

            await this.unityOfWork.Commit();

            return new CreatePostResponse()
            {
                Create = newPost.Create,
                Description = newPost.Description.Value,
                ResponsableId = responsable.Id
            };
        }
        public async Task<ListPostResponse> ListPosts(Guid responsableId)
        {
            List<Post> posts = await listPosts.ListPosts(responsableId);

            List<PostDto> postsDto = posts.Select(x => new PostDto()
            {
                Create = x.Create,
                Description = x.Description.Value,
                Comments = x.Comments.Select(c => new CommentDto()
                {
                    Create = c.Create,
                    Description = c.Description.Value,
                    Responsable = c.ResponsableId.ToString()
                }).ToList()
            }).ToList();

            return new ListPostResponse()
            {
                Posts = postsDto
            };
        }

        public Task RemovePost(Guid responsableId, Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}
