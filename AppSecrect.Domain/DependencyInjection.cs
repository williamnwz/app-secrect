
namespace AppSecrect.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AppSecrect.Domain.Services;
    using AppSecrect.Domain.Services.Interfaces;
    using AppSecrect.Domain.Services.SearchPosts;
    using Microsoft.Extensions.DependencyInjection;


    /// <summary>
    /// DependencyInjection
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISaveUser, SaveUser>();
            serviceCollection.AddScoped<ICreatePost, CreatePost>();
            serviceCollection.AddScoped<IUserAuthentication, UserAuthentication>();
            serviceCollection.AddScoped<IMakeFriendship, MakeFriendship>();
            serviceCollection.AddScoped<IListPosts, ListPostsFromTheLastFiveDays>();
            serviceCollection.AddScoped<ICreateComment, CreateComment>();
            serviceCollection.AddScoped<IRemovePost, RemovePost>();

            return serviceCollection;
        }
    }
}
