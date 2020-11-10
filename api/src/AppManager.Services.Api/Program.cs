using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AppManager.Domain.Entities;
using AppManager.Infrastructure.Data.Context;

namespace AppManager.Services.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();

      //using (var scope = host.Services.CreateScope())
      //{
      //  var db = scope.ServiceProvider.GetRequiredService<DataContext>();
      //  db.Database.Migrate();

      //  if (!db.Cities.ToList().Any())
      //  {
      //    db.Add(new City()
      //    {
      //      Name = "Curitiba",
      //      Status = true
      //    });
      //    db.Add(new City()
      //    {
      //      Name = "Florianópolis",
      //      Status = true
      //    });

      //    db.Add(new City()
      //    {
      //      Name = "Porto Alegre",
      //      Status = true
      //    });

      //    db.SaveChanges();

      //  }
      //}

      host.Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      var host = Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
            webBuilder.UseStartup<Startup>();
          });

      return host;

    }

  }
}
