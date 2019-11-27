namespace AppSecrect.Application.Services.Interfaces
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPostService
    {
        Task CreatePost(Guid responsableId, string description);
        Task RemovePost(Guid responsableId, Guid postId);
        Task<ListPostResponse> ListPosts(Guid responsableId);
    }
}
