using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using AppManager.Application.AutoMapper;
using AppManager.Application.Interfaces;
using AppManager.Application.Services;
using AppManager.Domain.Interfaces;
using AppManager.Domain.Interfaces.Services;
using AppManager.Domain.Services;
using AppManager.Infrastructure.Data.Context;
using AppManager.Infrastructure.Data.Repositories;

namespace AppManager.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddControllers();

            services.AddAutoMapper(typeof(DtoToEntityProfile), typeof(EntityToDtoProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AppManager API for Upper",
                    Description = "A simple API for search AppManager to test Upper",
                    Contact = new OpenApiContact
                    {
                        Name = "Carlos Cortez",
                        Email = "carlos.cfcortez@gmail.com",
                        Url = new Uri("https://github.com/carloscfcortez"),
                    },
                });
            });


            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IGroupAppService, GroupAppService>();
            services.AddTransient<IGroupRepository, GroupRepository>();


            services.AddTransient<ISpecieService, SpecieService>();
            services.AddTransient<ISpecieAppService, SpecieAppService>();
            services.AddTransient<ISpecieRepository, SpecieRepository>();


            services.AddTransient<ITreeService, TreeService>();
            services.AddTransient<ITreeAppService, TreeAppService>();
            services.AddTransient<ITreeRepository, TreeRepository>();


            services.AddTransient<IHarvestService, HarvestService>();
            services.AddTransient<IHarvestAppService, HarvestAppService>();
            services.AddTransient<IHarvestRepository, HarvestRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppManager API for Upper");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin();
                opt.AllowAnyMethod();
                opt.AllowAnyHeader();
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
