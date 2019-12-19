using AppSecrect.Application.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CreateCommentReponse> CreateComment(Guid responsableId, Guid postId, string description, string alias, string colorProfileUsed);
    }
}
