
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Nh.HelloWorld
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            //Configuration = builder.Build();
            //var myConnString = Configuration.GetConnectionString("SQLConn");


            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<CroweApp>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());

            // add logging
            serviceCollection.AddLogging();

            // build configuration
            IConfigurationRoot configuration = GetConfiguration();
            serviceCollection.AddSingleton(configuration);

            serviceCollection.AddOptions();
            serviceCollection.Configure<CroweAppSettings>(configuration.GetSection("Configuration"));

            serviceCollection.AddTransient<ITestService, TestService>();
            serviceCollection.AddTransient<CroweApp>();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
        }
    }
}
