using Microsoft.Extensions.DependencyInjection;

namespace Srinadimpalli.UltimateAspnetCoreApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors();
    }
}
