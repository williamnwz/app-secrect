namespace AppSecrect.Domain.Entities
{
    using AppSecrect.Domain.Exceptions;
    using AppSecrect.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Post
    /// </summary>
    public class Post : Entity
    {
        protected Post()
        {
        }
        public Post(User responsable, string description)
        {
            this.Create = DateTime.UtcNow;
            this.Description = new Description(description);
            this.Responsable = responsable;
            this.ResponsableId = responsable.Id;
        }

        public Guid ResponsableId { get; protected set; }
        public User Responsable { get; protected set; }
        public DateTime Create { get; protected set; }
        public Description Description { get; protected set; }
        public List<Comment> Comments { get; protected set; }

        public void IncludeComment(Comment comment)
        {

            if (!comment.Description.IsValid())
                throw new DomainException("Description is invalid");

            if (comment.Responsable == null)
                throw new DomainException("Responsable is not set");

            if (this.Comments == null)
                this.Comments = new List<Comment>();

            this.Comments.Add(comment);
        }
    }
}
