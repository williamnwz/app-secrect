
namespace AppSecrect.Application.Services
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Application.Mappers;
    using AppSecrect.Application.Services.Interfaces;
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// UserService
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IDtoMapper<User, CreateUser> regiserUserMapper;
        private readonly ISaveUser createUser;
        private readonly IUnityOfWork unityOfWork;
        private readonly IDtoMapper<LoginResponse, User> userToLoginResponseMapper;
        private readonly IDtoMapper<User, LoginDto> userDtoToUserMapper;
        private readonly IUserAuthentication userAuthentication;
        private readonly IMakeFriendship makeFriendship;

        public UserService(
            IDtoMapper<User, CreateUser> regiserUserMapper,
            IDtoMapper<User, LoginDto> userDtoToUserMapper,
            IDtoMapper<LoginResponse, User> userToLoginResponseMapper,
            ISaveUser createUser,
            IUserAuthentication userAuthentication,
            IMakeFriendship makeFriendship,
            IUnityOfWork unityOfWork)
        {
            this.regiserUserMapper = regiserUserMapper;
            this.createUser = createUser;
            this.userToLoginResponseMapper = userToLoginResponseMapper;
            this.userDtoToUserMapper = userDtoToUserMapper;
            this.userAuthentication = userAuthentication;
            this.makeFriendship = makeFriendship;
            this.unityOfWork = unityOfWork;
        }

        public async Task<LoginResponse> Login(LoginDto loginDto)
        {
            User user = this.userDtoToUserMapper.Convert(loginDto);

            string token = await this.userAuthentication.Authenticate(user);

            LoginResponse response = userToLoginResponseMapper.Convert(user);

            response.Token = token;

            return response;
        }

        public async Task MakeFriend(Guid me, Guid friend)
        {
            await makeFriendship.NewFriend(me, friend);

            await unityOfWork.Commit();
        }

        public async Task Register(CreateUser dto)
        {

            User user = regiserUserMapper.Convert(dto);

            await this.createUser.SaveUserAsync(user);

            await this.unityOfWork.Commit();
        }
    }
}
