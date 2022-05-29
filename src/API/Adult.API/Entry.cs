using Adult.API.Core.DAL;
using Adult.API.Identity.BLL.MapperProfiles;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Adult.API
{
    public static class Entry
    {
        public static IServiceCollection ConfigureCoreDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<CoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new Profile[]
                {
                        new UserMapperProfile(),
                });
            })
                .CreateMapper());

            return services;
        }
    }
}
