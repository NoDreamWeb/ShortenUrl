using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebTeam.Utility.ShortenUrl
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddShortenUrl(this IServiceCollection services)
        {
            
            services.AddSingleton<IShortenUrl>(x=>new Bitly(x.GetService<IOptions<ShortenUrlOptions>>().Value));

            return services;
        }
    }
}
