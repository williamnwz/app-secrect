namespace AppSecrect.Domain.Services.Interfaces
{
    using AppSecrect.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public interface IRemoveComment
    {
        Task Remove(Comment comment);
    }
}
