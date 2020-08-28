using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WebTeam.Utility.ShortenUrl
{
    public static class ServiceExtensions
    {
        private const string SETTING_NAME = "ShortenUrl";
        public static IServiceCollection AddShortenUrl(this IServiceCollection services, IConfiguration configuration)
        {
            var shortenUrlSettings = configuration.GetSection(SETTING_NAME);
            services.Configure<ShortenUrlOptions>(shortenUrlSettings);

            services.AddSingleton(x =>
            ShortenUrlFactory.Create(
            x.GetService<IOptions<ShortenUrlOptions>>().Value
            ));
            return services;
        }
    }
}
