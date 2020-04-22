using Autofac;
using MicroApp.Common;
using MicroApp.Common.Dispatcher;
using MicroApp.Common.Mongo;
using MicroApp.Common.Mvc;
using MicroApp.Common.RabbitMq;
using MicroApp.Common.Swagger;
using MicroApp.Products.Api.Domain;
using MicroApp.Products.Api.Messages.Commands;
using MicroApp.Products.Api.Messages.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace MicroApp.Products.Api
{
    public class Startup
    {
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count" };
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddSwaggerDocs();
            services.AddInitializers(typeof(IMongoDbInitializer));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithExposedHeaders(Headers));
            });
            services.AddControllers().AddNewtonsoftJson();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.AddDispatchers();
            builder.AddMongo();
            builder.AddMongoRepository<Product>("Products");
            builder.AddMongoRepository<ProductCategory>("ProductCategories");
            builder.AddRabbitMq();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseErrorHandler();

            app.UseRabbitMq()
                .SubscribeCommand<AddProduct>(onError: (c, e) =>
                    new AddProductRejected(c.Id, e.Message, e.Code))
                .SubscribeCommand<AddProductCategory>(onError: (c, e) =>
                    new AddProductCategoryRejected(c.Id, e.Message, e.Code));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            startupInitializer.InitializeAsync();
        }
    }
}
