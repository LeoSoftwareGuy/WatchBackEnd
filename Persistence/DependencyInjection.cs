using Application.Support.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WatchBackEndDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WatchShopDatabase")));

            services.AddScoped<IWatchBackEndDBContext>(provider => provider.GetService<WatchBackEndDBContext>());

            return services;
        }
    }
}
