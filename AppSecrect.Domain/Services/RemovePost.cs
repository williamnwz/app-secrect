namespace AppSecrect.Domain.Services
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class RemovePost : IRemovePost
    {
        private readonly IPostRepository postRepository;

        public RemovePost(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task Remove(Post post)
        {
            if (post == null)
                throw new Exception("There are no post to remove");

            Post postToRemove = await this.postRepository.GetByIdAsync(post.Id);

            await this.postRepository.RemoveAsync(postToRemove);
        }
    }
}
