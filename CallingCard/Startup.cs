using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CallingCard
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //UseMvc tell ASP.NET Core to look in the Controllers directory for a Controller with Methods and Routing to use!
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //other middleware goes below this 
            app.UseMvc();
            // routes =>
            // {
            //     routes.MapRoute(
            //         name:"Default", //the route's name is only for our own reference
            //         template:"", //the pattern that the route matches
            //         defaults: new {controller = "Hello", action = "Index"} //the controller and method to execute
            //         //action is a route 
            //         //controler is refering to the class name in controllers.cs file 
            //     );
            // }
        }
    }
}
