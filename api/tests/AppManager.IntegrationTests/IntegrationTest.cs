using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using AppManager.Infrastructure.Data.Context;
using AppManager.Services.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppManager.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient Client;
        public IntegrationTest()
        {

            var appFactory = new WebApplicationFactory<Startup>()
            .WithWebHostBuilder(builder =>
            {
                //builder.ConfigureAppConfiguration(x =>
                //{

                //});

                builder.ConfigureServices(services =>
                {
                    var descriptor = services
                    .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataContext>));
                    services.Remove(descriptor);

                    //services.RemoveAll<DataContext>();
                    services.AddDbContext<DataContext>(opt =>
                    {
                        opt.UseInMemoryDatabase("AppManagerTest");
                    });


                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<DataContext>();

                        db.Database.EnsureCreated();

                        try
                        {
                            InitializeDbTests(db);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                });
            });

            Client = appFactory.CreateClient();

        }

        public static void InitializeDbTests(DataContext context)
        {
            
        }

    }
}
