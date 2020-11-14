using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AppManager.IntegrationTests
{
    public class AppFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                              .ConfigureWebHostDefaults(x =>
                              {
                                  x.UseStartup<T>().UseTestServer();
                                  x.UseEnvironment("Development");
                              }).ConfigureAppConfiguration((hostingContext, config) =>
                              {
                                  config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
                              });

            return builder;
        }
        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.UseStartup<T>();
        //    builder.UseEnvironment("Development");
        //}
    }
}
