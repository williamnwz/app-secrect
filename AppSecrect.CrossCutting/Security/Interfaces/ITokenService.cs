using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.CrossCutting.Security.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(Guid id, string name, params string[] roles);
    }
}
