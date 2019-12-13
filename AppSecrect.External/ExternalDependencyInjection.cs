namespace AppSecrect.External
{
    using AppSecrect.CrossCutting.Settings;
    using AppSecrect.External.NameGenerator;
    using AppSecrect.External.NameGenerator.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public static class ExternalDependencyInjection
    {
        public static IServiceCollection AddExternalServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<INameGenerate, NameGenerateService>();
            return services;
        }
    }
}
