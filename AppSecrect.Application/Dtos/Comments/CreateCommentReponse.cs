namespace AppSecrect.Application.Dtos.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateCommentReponse
    {
        public string Description { get; set; }
        public Guid ResponsableId { get; set; }
        public DateTime Create { get; set; }
    }
}
