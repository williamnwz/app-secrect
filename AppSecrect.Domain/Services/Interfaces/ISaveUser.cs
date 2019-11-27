namespace AppSecrect.Domain.Services.Interfaces
{
    using AppSecrect.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// ICreateUser
    /// </summary>
    public interface ISaveUser
    {
        Task SaveUserAsync(User user);
    }
}
