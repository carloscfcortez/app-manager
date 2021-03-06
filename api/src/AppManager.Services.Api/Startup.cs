﻿using AutoMapper;
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
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace AppManager.Services.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            if (!env.IsProduction())
            {
                builder.SetBasePath(env.ContentRootPath)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                builder.AddEnvironmentVariables();
                Configuration = builder.Build();
            }
            else
            {
                /// Console.WriteLine("POSTGRES_CONNECTION: " + Environment.GetEnvironmentVariable("POSTGRES_CONNECTION").ToString());
                if (env.IsProduction())
                {
                    builder.SetBasePath(env.ContentRootPath);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                    var stringValue = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION");
                  

                    var jsonObj = JObject.Parse(File.ReadAllText(filePath));
                    var connections = jsonObj.SelectToken("ConnectionStrings");
                    connections.Replace(JObject.FromObject(new { PostgresConnection = stringValue }));

                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(filePath, output);

                    builder.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
                    builder.AddEnvironmentVariables();
                    Configuration = builder.Build();

                }

                Configuration = configuration;
            }


        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

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
                    Title = "AppManager API",
                    Description = "A simple API for search AppManager",
                    Contact = new OpenApiContact
                    {
                        Name = "Carlos Cortez",
                        Email = "carlos.cfcortez@gmail.com",
                        Url = new Uri("https://github.com/carloscfcortez"),
                    },
                });
            });


            // services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppManager API");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
