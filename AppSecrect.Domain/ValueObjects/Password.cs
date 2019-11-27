
using AppSecrect.Domain.Exceptions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AppSecrect.Domain.ValueObjects
{
    /// <summary>
    /// Password
    /// </summary>
    public class Password : ValueObject<string>
    {

        protected Password() { }
        public Password(string value, bool encrypt = true, bool validate = false) : base(value)
        {
            this.Value = value;

            if (validate && !this.IsValid())
                throw new DomainException("Invalid Password");

            if (encrypt) { Encrypt(); }
        }

        public override bool IsValid()
        {
            bool hasNumber = new Regex("[0-9]+").IsMatch(this.Value);
            bool hasUpperCase = new Regex("[A-Z]+").IsMatch(this.Value);
            bool hasUnderCase = new Regex("[a-z]+").IsMatch(this.Value);
            bool hasSpecialCharacter = new Regex("[!@#$%¨&*()_+]+").IsMatch(this.Value);
            return (hasNumber && hasUpperCase && hasUnderCase && hasSpecialCharacter);
        }

        public void Encrypt()
        {
            this.Value = GetHashString(this.Value);
        }

        private string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
    }
}
