using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebTeam.Utility.ShortenUrl;

namespace TestingConsole
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            ServiceProvider serviceProvider = new DIServiceProvider().ServiceProvider;
            IShortenUrl shortenUrl = serviceProvider.GetService<IShortenUrl>();
            Console.WriteLine("start");
            var test= await shortenUrl.GetShorten(new System.Collections.Generic.Dictionary<string, string>() {
                { "long_url","https://dev.otandp.com:18080/hk-oap/oa"}
            });
        }
    }
}
