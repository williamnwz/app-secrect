using AppSecrect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Domain.Services.Interfaces
{
    public interface ICreateComment
    {
        Task Comment(Comment comment);
    }
}
