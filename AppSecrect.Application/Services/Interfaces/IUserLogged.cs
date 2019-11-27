using AppSecrect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Application.Services.Interfaces
{
    public interface IUserLogged
    {
        Task<Guid> GetUserId();
    }
}
