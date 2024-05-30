using Education.Application.UseCases.AuthServise;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application
{
    public static class EducationDependencyInjection
    {
        public static IServiceCollection AddEducationApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthServise,AuthServise>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
