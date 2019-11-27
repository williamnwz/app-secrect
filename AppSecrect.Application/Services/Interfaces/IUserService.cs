
namespace AppSecrect.Application.Services.Interfaces
{
    using AppSecrect.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// IUserService
    /// </summary>
    public interface IUserService
    {
        Task Register(CreateUser dto);

        Task<LoginResponse> Login(LoginDto loginDto);

        Task MakeFriend(Guid me, Guid friend);
    }
}
