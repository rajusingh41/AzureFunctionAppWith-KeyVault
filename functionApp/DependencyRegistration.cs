using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace functionApp
{
    internal class DependencyRegistration
    {
        internal static void ConfigureProductionDependencies(HostBuilderContext context, IServiceCollection collection)
        {
            throw new NotImplementedException();
        }

        internal static void ConfigureStaticDependencies(HostBuilderContext context, IServiceCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}