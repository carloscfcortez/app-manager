
using AppManager.Application.Interfaces;
using AppManager.Application.Services;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


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
            services.AddTransient<ITreeAppService, TreeAppService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostEnvironment env)
        {
            app.UseMvc();
        }
    }
}
