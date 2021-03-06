﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
//
using Orders.Schema;
using Orders.Services;

namespace Server
{
  public class Startup
  {
    public Startup(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public IHostingEnvironment Environment { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // Register services
      services.AddSingleton<IOrderService, OrderService>();
      services.AddSingleton<ICustomerService, CustomerService>();
      services.AddSingleton<OrderType>();
      services.AddSingleton<CustomerType>();
      services.AddSingleton<OrderStatusesEnum>();
      services.AddSingleton<OrdersQuery>();
      services.AddSingleton<OrdersSchema>();
      services.AddSingleton<OrderCreateInputType>();
      services.AddSingleton<OrdersMutation>();
      services.AddSingleton<OrdersSubscription>();
      services.AddSingleton<OrderEventType>();
      services.AddSingleton<IOrderEventService, OrderEventService>();
      services.AddSingleton<IDependencyResolver>(
          c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
      
      services.AddGraphQL(options=> {
                options.EnableMetrics = true;
                options.ExposeExceptions = Environment.IsDevelopment();
            })
            .AddWebSockets()
            .AddDataLoader();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseWebSockets();
        // app.UseGraphQLWebSocket<OrdersSchema>(new GraphQLWebSocketsOptions());
        // app.UseGraphQLHttp<OrdersSchema>(new GraphQLHttpOptions());
    }
  }
}
