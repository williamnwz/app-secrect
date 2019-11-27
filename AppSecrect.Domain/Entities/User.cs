namespace AppSecrect.Domain.Entities
{
    using AppSecrect.Domain.Exceptions;
    using AppSecrect.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// User
    /// </summary>
    public class User : Entity
    {
        public User()
        {

        }
        public User(
            string login,
            string email,
            string password)
        {
            this.Password = new Password(password, false);
            this.Login = new Login(login);
            this.Email = new Email(email);
        }

        public string FacebookId { get; protected set; }
        public Login Login { get; protected set; }
        public Email Email { get; protected set; }
        public Password Password { get; protected set; }
        public virtual List<Friend> Friends { get; protected set; }
        public virtual List<Friend> MainUserFriends { get; protected set; }
        public List<Post> Posts { get; protected set; }

        public void IncludePost(Post post)
        {
            if (!post.Description.IsValid())
                throw new DomainException("Invalid description for the post");

            if (post.Responsable == null)
                throw new DomainException("The post don't have a responsable, please set a responsable for it");

            if (post.Responsable.Id == Guid.Empty || post.ResponsableId == Guid.Empty)
                throw new DomainException("The post don't have a responsable, please set a responsable for it");

            if (Posts == null)
                Posts = new List<Post>();

            this.Posts.Add(post);
        }

        public bool HaveIAlreadyThisFriend(User frind)
        {
            if (this.MainUserFriends == null)
                this.MainUserFriends = new List<Friend>();

            if (this.Friends == null)
                this.Friends = new List<Friend>();

            if (this.Friends.Any(x => x.FriendId == frind.Id)) { return true; }

            if (this.MainUserFriends.Any(x => x.FriendId == frind.Id)) { return true; }

            return false;
        }

        public void MakeFriend(User user)
        {
            if (!this.HaveIAlreadyThisFriend(user))
            {
                if (this.MainUserFriends == null)
                    this.MainUserFriends = new List<Friend>();

                if (this.Friends == null)
                    this.Friends = new List<Friend>();

                this.MainUserFriends.Add(new Friend(this, user));

                this.Friends.Add(new Friend(user, this));
            }
            else
            {
                throw new DomainException("This user is already a friend!");
            }
        }

    }
}
