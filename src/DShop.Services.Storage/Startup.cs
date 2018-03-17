using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DShop.Common.Mongo;
using DShop.Common.Mvc;
using DShop.Common.RabbitMq;
using DShop.Common.Redis;
using DShop.Messages.Events.Customers;
using DShop.Messages.Events.Identity;
using DShop.Messages.Events.Products;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Models.Products;
using DShop.Services.Storage.ServiceForwarders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestEase;
using DShop.Common.RestEase;
using DShop.Services.Storage.Models.Orders;
using DShop.Messages.Events.Orders;

namespace DShop.Services.Storage
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddDefaultJsonOptions();
            services.AddRedisCache();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();

            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddMongoDB();
            builder.AddMongoDBRepository<Customer>("Customers");
            builder.AddMongoDBRepository<Product>("Products");
            builder.AddMongoDBRepository<Order>("Orders");
            builder.RegisterServiceForwarder<ICustomersService>("customers-service");
            builder.RegisterServiceForwarder<IProductsService>("products-service");
            builder.RegisterServiceForwarder<IOrdersService>("orders-service");

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseErrorHandler();
            app.UseRabbitMq()
                .SubscribeEvent<SignedUp>()
                .SubscribeEvent<CustomerCreated>()
                .SubscribeEvent<ProductCreated>()
                .SubscribeEvent<ProductUpdated>()
                .SubscribeEvent<ProductDeleted>()
                .SubscribeEvent<ProductAddedToCart>()
                .SubscribeEvent<ProductDeletedFromCart>()
                .SubscribeEvent<CartCleared>()
                .SubscribeEvent<OrderCreated>()
                .SubscribeEvent<OrderCanceled>()
                .SubscribeEvent<OrderCompleted>();

            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
