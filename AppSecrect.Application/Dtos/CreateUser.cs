namespace AppSecrect.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// RegisterUserDto
    /// </summary>
    public class CreateUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
