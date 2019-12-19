using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.GraphiQL;
using aspnetcoreapp.GraphQL;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace aspnetcoreapp
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

#if NETCOREAPP3_0
            // Workaround until GraphQL can swap off Newtonsoft.Json and onto the new MS one.
            // Depending on whether you're using IIS or Kestrel, the code required is different
            // See: https://github.com/graphql-dotnet/graphql-dotnet/issues/1116
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
#endif
            services.AddSingleton<IAuthor, AuthorDetails>()                
            .AddSingleton<GraphSchema>()
            // Add GraphQL services and configure options
            .AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
                options.UnhandledExceptionDelegate = ctx =>
                {
                    Console.WriteLine("error: " + ctx.OriginalException.Message);
                };
            })
            .AddWebSockets()
            .AddDataLoader()
            .AddGraphTypes(typeof(GraphSchema));
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // this is required for websockets support
            app.UseWebSockets();
          
            // use websocket middleware for ChatSchema at path /graphql
            app.UseGraphQLWebSockets<GraphSchema>("/graphql");

            app.UseGraphQL<GraphSchema, GraphQLHttpMiddleware<GraphSchema>>("/graphql");

            app.UseGraphiQLServer(new GraphiQLOptions
            {
                Path = "/ui/graphiql",
                GraphQLEndPoint = "/graphql",
            });
            
        }
    }
}
