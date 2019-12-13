

namespace AppSecrect.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CreatePostRequest
    {
        public string Description { get; set; }

        public string Alias { get; set; }

        public string ColorProfileUsed { get; set; }
    }
}
