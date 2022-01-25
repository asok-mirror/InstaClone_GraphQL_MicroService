using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Post.Data.datacontext;
using Post.Data.dataseeder;
using Post.Data.repositories;
using Post.GraphQL;
using Post.Services;
using HotChocolate;
using Post.AutoMapperProfiles;

namespace Post
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
            services.AddAutoMapper(c => c.AddProfile<AutoMapperProfile>(), typeof(Startup));
            services.AddDbContextPool<PostDataContext>(options => options.UseInMemoryDatabase(databaseName: "Post"));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPostService, PostService>();
            services.AddControllers();

            //graphql
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections() //Projects incoming queries to db
                .AddFiltering() //adds filtering capabilities to the schema
                .AddSorting(); //adds filtering capabilities to the schema
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Post v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //seed in-memory database
            SeedDatabase(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL(); //default path - /graphql              
            });
        }

        private static void SeedDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PostDataContext>();

                context.Database.EnsureCreated();

                new PostContextSeed(context).SeedPost();

                context.SaveChanges();
            }
        }
    }
}
