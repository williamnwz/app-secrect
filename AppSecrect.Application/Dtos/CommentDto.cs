using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.Application.Dtos
{
    public class CommentDto
    {
        public string Description { get; set; }
        public DateTime Create { get; set; }
        public string Responsable { get; set; }
    }
}
