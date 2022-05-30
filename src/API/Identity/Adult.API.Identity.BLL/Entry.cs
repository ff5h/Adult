using Adult.API.Identity.BLL.Configurations;
using Adult.API.Identity.BLL.Implementations;
using Adult.API.Identity.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Adult.API.Identity.BLL
{
    public static class Entry
    {
        public static IServiceCollection ConfigureJwtAuthService(this IServiceCollection services, JwtConfiguration jwtConfiguration)
        {
            services.AddSingleton(jwtConfiguration);
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IJwtTokenManager, JwtTokenManager>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
