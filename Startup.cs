using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VUEAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080", "http://192.168.1.106", 
                                            "https://192.168.1.106:8085", "https://localhost:8085")
                                .AllowAnyMethod()
                                .AllowAnyHeader() 
                                .AllowCredentials();
                    });
            });

            services.AddControllers();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.Use(async (ctx, next) => {             
                await next();
            });

            app.UseCors("AllowAll");

            app.Use(async(ctx, next) => {

                if (ctx.Request.Method == "OPTIONS")
                {
                    ctx.Response.StatusCode = 207;
                    await ctx.Response.CompleteAsync();
                }
                else {
                    await next();
                }

            });

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
