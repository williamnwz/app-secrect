﻿namespace AppSecrect.Application.Services.Interfaces
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Application.Dtos.Posts;
    using AppSecrect.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public interface IPostService
    {
        Task<CreatePostResponse> CreatePost(Guid responsableId, string description, string alias, string colorProfileUsed);
        Task RemovePost(Guid responsableId, Guid postId);
        Task<ListPostResponse> ListPosts(Guid responsableId);
    }
}
