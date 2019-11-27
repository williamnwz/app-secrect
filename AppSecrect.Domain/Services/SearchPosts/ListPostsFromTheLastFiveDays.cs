namespace AppSecrect.Domain.Services.SearchPosts
{
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ListPostsFromTheLastFiveDays : IListPosts
    {

        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        public ListPostsFromTheLastFiveDays(
            IUserRepository userRepository,
            IPostRepository postRepository)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
        }

        public async Task<List<Post>> ListPosts(Guid responsableId)
        {
            User user = await this.userRepository.GetUserByIdWithFriends(responsableId);

            List<Guid> friendsId = new List<Guid>();
            friendsId.AddRange(user.MainUserFriends.Select(x => x.FriendId).ToList());
            friendsId.Add(responsableId);

            List<Post> posts = await this.postRepository.ListPostWithComment(DateTime.Now.AddDays(-5), friendsId);

            return posts;
        }
    }
}
