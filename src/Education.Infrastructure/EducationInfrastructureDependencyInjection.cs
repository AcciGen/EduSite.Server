using Education.Application.Abstractions;
using Education.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Infrastructure
{
    public static class EducationInfrastructureDependencyInjection
    {
        public static IServiceCollection AddEducationINfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IEducationDbContext,EducationDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
