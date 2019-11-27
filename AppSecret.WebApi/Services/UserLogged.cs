using AppSecrect.Application.Services.Interfaces;
using AppSecrect.CrossCutting.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppSecret.WebApi.Services
{
    public class UserLogged : IUserLogged
    {
        private readonly ControllerBase controller;
        public UserLogged(ControllerBase controller)
        {
            this.controller = controller;
        }

        public async Task<Guid> GetUserId()
        {
            Claim claim = this.controller.User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                throw new ApplicationException("Invalid User");

            Guid responsableId;
            if (Guid.TryParse(claim.Value, out responsableId))
            {
                return responsableId;
            }
            throw new ApplicationException("Invalid User");
        }
    }
}
