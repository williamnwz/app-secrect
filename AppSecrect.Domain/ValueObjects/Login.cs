namespace AppSecrect.Domain.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Login
    /// </summary>
    public class Login : ValueObject<string>
    {
        protected Login() : base()
        {
        }
        public Login(string login) : base(login)
        {
        }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Value) && this.Value.Length > 2;
        }

        public string Anonimo()
        {
            return "";
        }
    }
}
