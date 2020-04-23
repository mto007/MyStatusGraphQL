
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphiQl;
using GraphQL;
using GraphQL.Http;
using MyStatusGraphQL.Graphql;
using MyStatusGraphQL.Database;
using GraphQL.Types;
using MyStatusGraphQL.Entities;

namespace MyStatusGraphQL
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

            services.AddDbContext<MentalStatusDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
               ServiceLifetime.Scoped,
               ServiceLifetime.Scoped);
            services.AddSingleton<GraphQLQuery>();

            services.AddSingleton<MentalStatus>();
            services.AddSingleton<MentalStatusType>();
            services.AddScoped<MentalStatusQuery>();
            services.AddScoped<MentalStatusMutation>();
            services.AddScoped<ISchema, MentalStatusSchema>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:8080")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials();
                    });
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl("/graphql");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
