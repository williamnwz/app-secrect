namespace AppSecret.WebApi
{
    using System.Text;
    using AppSecrect.Application;
    using AppSecrect.CrossCutting;
    using AppSecrect.CrossCutting.Settings;
    using AppSecrect.DataAccess;
    using AppSecrect.Domain;
    using AppSecrect.External;
    using AppSecret.WebApi.Filters;
    using AppSecret.WebApi.Hubs;
    using AppSecret.WebApi.Services;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors();
            services.AddControllers();



            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            var appSettings = new AppSettings();

            Configuration.Bind("AppSettings", appSettings);


            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddTransient<AppSettings>(x =>
            {
                return appSettings;
            });

            services
                .AddDomain()
                .AddDataAccess(appSettings)
                .AddApplicationServices()
                .AddCrossCuttingDependencies(appSettings)
                .AddExternalServicesDependencies();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppSecrect", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });

            services.AddSignalR();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            
            services.AddMvc(options =>
            {
                options.Filters.Add(new ApiExceptionFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppSecrect");
            });

            ServiceLocator.ServiceProvider = app.ApplicationServices;

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x =>

                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PostNotificationHub>("/PostNotificationHub");
                endpoints.MapHub<CommentNotificationHub>("/commentNotificationHub");
                
            });
        }


    }
}
