using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.Application.Dtos.Posts
{
    public class CreatePostResponse
    {
        public string Description { get; set; }
        public Guid ResponsableId { get; set; }
        public DateTime Create { get; set; }

    }
}
