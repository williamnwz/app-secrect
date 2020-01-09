

namespace AppSecrect.CrossCutting
{
    using AppSecrect.CrossCutting.Security;
    using AppSecrect.CrossCutting.Security.Interfaces;
    using AppSecrect.CrossCutting.Settings;
    
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Text;
    public static class DependencyInjection
    {
        public static IServiceCollection AddCrossCuttingDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<ITokenService, JwtTokenService>();

       

            return services;
        }
    }
}
