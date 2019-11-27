using AppSecrect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Domain.Services.Interfaces
{
    public interface IUserAuthentication
    {
        Task<string> Authenticate(User user);
    }
}
