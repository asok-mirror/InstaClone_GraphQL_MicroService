using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Post.Services;
using System;
using HotChocolate.AspNetCore;
using HotChocolate;

namespace Gateway
{
    public class Startup
    {
        //services to hookup
        public const string Posts = "posts";
        public const string Users = "users";
        public const string Comments = "comments";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IGatewayService, GatewayService>();
            //services.AddControllers();

            services.AddHttpClient(Posts, c => c.BaseAddress = new Uri("http://localhost:5001/graphql"));
            services.AddHttpClient(Comments, c => c.BaseAddress = new Uri("http://localhost:4087/graphql"));
            services.AddHttpClient(Users, c => c.BaseAddress = new Uri("http://localhost:5005/graphql"));

            services.AddGraphQLServer()
                    .AddQueryType(d => d.Name("Query"))
                    .AddRemoteSchema(Posts, ignoreRootTypes: true)
                    .AddRemoteSchema(Comments, ignoreRootTypes: true)
                    .AddRemoteSchema(Users, ignoreRootTypes: true)
                    .AddTypeExtensionsFromFile("./Stitching.graphql");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
