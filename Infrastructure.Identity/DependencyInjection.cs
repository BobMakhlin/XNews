
using Infrastructure.Identity.DataAccess;
using Infrastructure.Identity.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the DbContext, used to store identity tables.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddIdentityDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(InfrastructureIdentityOptions.IdentityDatabase);
            services.AddDbContext<XNewsIdentityDbContext>
            (
                options => options.UseSqlServer(connectionString)
            );

            return services;
        }

        /// <summary>
        /// Registers the identity system on the specified <paramref name="services"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddIdentitySystem(this IServiceCollection services)
        {
            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<XNewsIdentityDbContext>();

            return services;
        }
    }
}