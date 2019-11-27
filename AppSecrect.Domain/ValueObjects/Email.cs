
namespace AppSecrect.Domain.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;


    /// <summary>
    /// Email
    /// </summary>
    public class Email : ValueObject<string>
    {

        protected Email() { }
        public Email(string value) : base(value)
        {
        }

        public override bool IsValid()
        {
            return 
                new Regex(@"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$")
                .IsMatch(this.Value);
        }


    }
}
