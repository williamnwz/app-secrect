﻿namespace AppSecret.WebApi.Controllers
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Application.Dtos.Users;
    using AppSecrect.Application.Services.Interfaces;
    using AppSecret.WebApi.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;


    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserLogged userLogged;

        public UserController(IUserService userService)
        {
            this.userService = userService;
            this.userLogged = new UserLogged(this);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<LoginResponse> Login([FromBody]LoginDto dto)
        {
            LoginResponse  response = await this.userService.Login(dto);

            return response;
        }

        [HttpPost]
        [Route("new-user")]
        public async Task<CreateUserResponse> Create([FromBody]CreateUser dto)
        {
           return await this.userService.Register(dto);
        }

        [HttpGet]
        [Route("test")]
        public async Task<string> Teste()
        {
            return "foi!";
        }

        [HttpPost]
        [Route("make-friend")]
        [AllowAnonymous]
        public async Task MakeFriend([FromBody]Guid friendUserId)
        {
            Guid me = await this.userLogged.GetUserId();

           await this.userService.MakeFriend(me, friendUserId);
        }



    }
}
