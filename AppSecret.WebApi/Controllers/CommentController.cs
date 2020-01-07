namespace AppSecret.WebApi.Controllers
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Application.Dtos.Comments;
    using AppSecrect.Application.Services.Interfaces;
    using AppSecret.WebApi.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("v1/comments")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IUserLogged userLogged;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
            this.userLogged = new UserLogged(this);
        }

        [HttpPost]
        [Route("new-comment")]
        public async Task<CreateCommentReponse> CreateComment([FromBody]CreateCommentRequest request)
        {
            Guid respnsable = await this.userLogged.GetUserId();

            return await this.commentService.CreateComment(respnsable, request.PostId, request.Description, request.Alias, request.ColorProfileUsed);
        }

        [HttpDelete]
        [Route("remove-comment")]
        public async Task RemoveComment([FromBody]Guid commentId)
        {
            Guid respnsable = await this.userLogged.GetUserId();

            await this.commentService.RemoveComment(respnsable, commentId);
        }
    }
}
