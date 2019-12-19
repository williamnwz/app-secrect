namespace AppSecret.WebApi.Controllers
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Application.Dtos.Posts;
    using AppSecrect.Application.Services.Interfaces;
    using AppSecret.WebApi.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("v1/posts")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IUserLogged userLogged;
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.userLogged = new UserLogged(this);
            this.postService = postService;
        }

        [HttpPost]
        [Route("new-post")]
        public async Task<CreatePostResponse> Create([FromBody]CreatePostRequest request)
        {
            Guid currentUserId = await this.userLogged.GetUserId();
            return await this.postService.CreatePost(currentUserId, request.Description, request.Alias, request.ColorProfileUsed);
        }

        [HttpGet]
        [Route("list-posts")]
        public async Task<ListPostResponse> ListPosts()
        {
            Guid responsableId = await userLogged.GetUserId();
            return await this.postService.ListPosts(responsableId);
        }



    }
}
