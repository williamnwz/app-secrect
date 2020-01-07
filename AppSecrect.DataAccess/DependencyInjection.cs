
namespace AppSecrect.DataAccess
{
    using AppSecrect.CrossCutting.Settings;
    using AppSecrect.DataAccess.Repositories;
    using AppSecrect.Domain.Entities;
    using AppSecrect.Domain.Repositories;
    using AppSecrect.Domain.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics;


    /// <summary>
    /// DependencyInjection
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddScoped<IRepository<Entity>, Repository<Entity>>();
            services.AddScoped<IUnityOfWork, Repository<Entity>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IFriendRepostory, FriendRepostory>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddDbContext<AppSecrectContext>(options => options.UseNpgsql(appSettings.Connection, opt =>
            {
                Debug.WriteLine("Connection String");
                Debug.WriteLine(appSettings.DbUri);
                opt.MigrationsAssembly("AppSecrect.DataAccess");
            }));

            return services;
        }
    }
}
