using System;
using System.IO;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    /*
                    var orderContext = services.GetRequiredService<OrderContext>();
                    var petContext = services.GetRequiredService<PetContext>();
                    var productContext = services.GetRequiredService<ProductContext>();
                    //read Mode from configure file 
                    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        
                    var config = builder.Build();
                    if (config.GetConnectionString("Mode") == "Dev")
                        DbInitializer.Initialize(productContext,petContext,orderContext,true);
                    else 
                        DbInitializer.Initialize(productContext,petContext,orderContext,false);
                        */
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occured creating the DB");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}