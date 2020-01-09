using AppSecrect.CrossCutting.Settings;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSecret.WebApi.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IServiceProvider serviceProvider;

        public ApiExceptionFilter()
        {
            this.serviceProvider = ServiceLocator.ServiceProvider;
            
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            return base.OnExceptionAsync(context);
        }
    }
}
