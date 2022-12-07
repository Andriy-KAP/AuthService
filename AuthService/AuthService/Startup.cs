using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AuthService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureService(IServiceCollection services)
        {
             services.AddMvc();
             services.AddIdentityServer()
                .AddInMemoryPersistedGrants()
                .AddInMemoryApiResources(new List<ApiResource>())
                .AddInMemoryIdentityResources(new List<IdentityResource>())
                .AddInMemoryApiScopes(new List<ApiScope>())
                .AddInMemoryClients(new List<Client>())
                .AddTestUsers(new List<TestUser>())
                .AddDeveloperSigningCredential();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
            //}
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            
        }
    }
}
