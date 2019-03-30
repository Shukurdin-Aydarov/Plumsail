using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Plumsail.Filters;

namespace Plumsail
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(ValidationFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddFluentValidation();

            services.ConfigureDbContext(Configuration)
                .ConfigureValidation()
                .RegisterModelServices()
                .ConfigureLocalization();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRequestLocalization();
            app.UseMvc();
        }
    }
}
