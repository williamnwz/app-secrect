
namespace AppSecrect.Application
{
    using AppSecrect.Application.Dtos;
    using AppSecrect.Application.Mappers;
    using AppSecrect.Application.Services;
    using AppSecrect.Application.Services.Interfaces;
    using AppSecrect.Domain.Entities;
    using Microsoft.Extensions.DependencyInjection;
    /// <summary>
    /// DependencyInjection
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IDtoMapper<User, CreateUser>, RegisterUserToUserMapper>();

            services.AddTransient<IDtoMapper<User, LoginDto>, LoginToUserDtoMapper>();

            services.AddTransient<IDtoMapper<LoginResponse, User>, UserToLoginResponseMapper>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPostService, PostService>();

            services.AddScoped<ICommentService, CommentService>();



            return services;
        }
    }
}
