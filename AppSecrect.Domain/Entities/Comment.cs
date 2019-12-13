
namespace AppSecrect.Domain.Entities
{
    using AppSecrect.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Comment
    /// </summary>
    public class Comment : Entity
    {

        protected Comment() { }
        public Comment(Post post, User responsable, string description, string alias, string colorProfileUsed)
        {
            this.Create = DateTime.UtcNow;
            this.Post = post;
            this.Responsable = responsable;
            this.ResponsableId = responsable.Id;
            this.PostId = post.Id;
            this.Description = new Description(description);

            this.Alias = alias;
            this.ColorProfileUsed = colorProfileUsed;
        }
        public string Alias { get; set; }
        public string ColorProfileUsed { get; set; }
        public Guid PostId { get; protected set; }
        public Post Post { get; protected set; }
        public DateTime Create { get; protected set; }
        public Description Description { get; protected set; }

        public Guid ResponsableId { get; protected set; }
        public User Responsable { get; protected set; }
    }
}
