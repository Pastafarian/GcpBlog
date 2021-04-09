using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GcpBlog.Application.Handlers.Query;
using GcpBlog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GcpBlog.Api
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
            services.AddMediatR(typeof(GetPosts));
            services.AddControllers();
            services.AddCors(x => x.AddPolicy("Any", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GcpBlog.Api", Version = "v1" });
            });

            services.AddDbContext<Context>(options => options.UseNpgsql(Configuration.GetConnectionString("GcpBlog")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GcpBlog.Api v1"));
            }

            app.UseRouting();
            app.UseCors("Any");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<Context>();

            try
            {
                context?.Database.Migrate();
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to run db migration. Potential error with connection string. {Configuration.GetConnectionString("GcpBlog")}", e);
            }
        }
    }
}
