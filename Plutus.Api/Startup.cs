﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plutus.Api.Bootstrap;
using Plutus.Business.Services;
using Plutus.Business.Services.Contracts;
using Plutus.Repository;
using Plutus.Repository.Contracts;

namespace Plutus.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcConfiguration();
            services.AddCorsConfiguration();
            services.AddSwaggerConfiguration();

            // Register Services from Business Logic
            services.AddSingleton<IAccountService, AccountService>();

            // Register Repositories from Data Access
            services.AddSingleton<IAccountRepository, AccountRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            app.UseMvc();
            app.UseAutoMapper();
            app.UseSwaggerUX();
        }
    }
}
