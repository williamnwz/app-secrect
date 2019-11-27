
namespace AppSecrect.CrossCutting.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ServiceLocator
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}
