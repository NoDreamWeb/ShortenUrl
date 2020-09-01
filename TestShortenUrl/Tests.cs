using NUnit.Framework;
using WebTeam.Utility.ShortenUrl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace TestShortenUrl
{
    public class Tests
    {
        private ServiceProvider _sp;
        private IConfigurationRoot _config;
        private const string SETTING_NAME = "ShortenUrl";
        [SetUp]
        public void Setup()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "netcoreapp3.1/appsettings.json");
            configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path, false);
             _config = configurationBuilder.Build();
            
        }

        [Test]
        public void Check_appsetting_file()
        {
            Assert.IsTrue(_config!=null);
        }

        [Test]
        public void Check_ShortenUrlOptions_Instance()
        {
            var serviceCollection = new ServiceCollection();
            var shortenUrlSettings = _config.GetSection(SETTING_NAME);
            serviceCollection.Configure<ShortenUrlOptions>(shortenUrlSettings);
            _sp = serviceCollection.BuildServiceProvider();
            Assert.IsTrue(_sp.GetService<IOptions<ShortenUrlOptions>>() != null);
        }

        [Test]
        public void Check_ShortenUrl_Instance()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddShortenUrl(_config);
            _sp = serviceCollection.BuildServiceProvider();
            Assert.IsTrue(_sp.GetService<IShortenUrl>()!=null);
        }



        [Test]
        public async Task Check_Bitly_Shorten_Method()
        {
            var serviceCollection = new ServiceCollection();
            var bitlyAccessToken = _config.GetValue<string>("ShortenUrl:Bitly:AccessToken");
            //skip if not set
            if (string.IsNullOrWhiteSpace(bitlyAccessToken))
                Assert.Inconclusive();

            var bity = new Bitly(
                new ShortenUrlOptions()
                {
                    Bitly = new System.Collections.Generic.Dictionary<string, string>()
                    {
                        { "AccessToken" , bitlyAccessToken}
                    }
                });
            var result = await bity.GetShorten(new BitlyParams() { long_url = "https://dev.otandp.com:18080/en/oa" });

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

    }
}