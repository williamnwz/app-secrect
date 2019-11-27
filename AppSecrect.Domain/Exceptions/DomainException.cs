namespace AppSecrect.Domain.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// DomainException
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message) :base(message)
        {
        }
    }
}
