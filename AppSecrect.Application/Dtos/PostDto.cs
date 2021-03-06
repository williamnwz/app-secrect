﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppSecrect.Application.Dtos
{
    public class PostDto
    {
        public string Alias { get; set; }
        public string ColorProfileUsed { get; set; }
        public DateTime Create { get; set; }
        public string Description { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
