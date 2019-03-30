using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

using Plumsail.Core.Localization;
using Plumsail.Core.Validation;
using Plumsail.Core.Models;
using Plumsail.Core.Repositories;
using Plumsail.Core.Services;

namespace Plumsail
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration
                .GetConnectionString(Conctants.DefaultConnection);

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connection));

            return services;
        }

        public static IServiceCollection RegisterModelServices(this IServiceCollection services)
        {
            return services.AddScoped<IContactService, ContactService>();
        }

        public static IServiceCollection ConfigureValidation(this IServiceCollection services)
        {
            return services.AddTransient<IValidator<Contact>, ContactValidator>();
        }

        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            return services.AddTransient<IStringLocalizer<Contact>, ContactLocalizer>();
        }
    }
}
