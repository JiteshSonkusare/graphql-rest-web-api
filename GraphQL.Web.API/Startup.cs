using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Web.API.Code;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQL.Web.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Entity DB context configuration
            services.AddDbContext<EmployeeDBContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // GraphQL configuration
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<EmployeeSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();

            // Now register our services with Autofac container
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacModule());
            builder.Populate(services);
            var container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add Schema to GraphQL
            app.UseGraphQL<EmployeeSchema>();

            //Use this method run graphql query on graphql playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseMvc();
        }
    }
}
