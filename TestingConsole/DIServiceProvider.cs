using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebTeam.Utility.ShortenUrl;

namespace TestingConsole
{
    public class DIServiceProvider
    {
        public DIServiceProvider()
        {
            var root = GetConfiguration();
            
            var hostEnv = new HostingEnvironment()
            {
                EnvironmentName = "local",
                ApplicationName = nameof(DIServiceProvider),
                ContentRootPath = System.AppDomain.CurrentDomain.BaseDirectory,
                ContentRootFileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            };
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddShortenUrl(root);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }


        public ServiceProvider ServiceProvider { get; private set; }

        private IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "netcoreapp3.1/appsettings.json");
            configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path, false);
            return configurationBuilder.Build();
        }
    }
}
