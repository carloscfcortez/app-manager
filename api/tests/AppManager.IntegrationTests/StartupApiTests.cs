using AppManager.Application.AutoMapper;
using AppManager.Application.Interfaces;
using AppManager.Application.Services;
using AppManager.Domain.Interfaces;
using AppManager.Domain.Interfaces.Services;
using AppManager.Domain.Services;
using AppManager.Infrastructure.Data.Context;
using AppManager.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppManager.IntegrationTests
{
    public class StartupApiTests
    {
        public StartupApiTests(IConfiguration configuration)
        {
            Configuration = configuration;
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

            //services.AddControllersWithViews().AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //});
            //services.AddControllers();

            //services.AddAutoMapper(typeof(DtoToEntityProfile), typeof(EntityToDtoProfile));

           

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

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostEnvironment env)
        {
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
