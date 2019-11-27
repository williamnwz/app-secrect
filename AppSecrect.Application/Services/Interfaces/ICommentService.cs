using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task CreateComment(Guid responsableId, Guid postId, string description);
    }
}
