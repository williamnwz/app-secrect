
namespace AppSecrect.Domain.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// PostDetails
    /// </summary>
    public class Description : ValueObject<string>
    {
        public Description(string value) : base(value)
        {
        }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Value);
        }
    }
}
