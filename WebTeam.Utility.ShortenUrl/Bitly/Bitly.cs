using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebTeam.Utility.ShortenUrl
{
    public class Bitly : IShortenUrl
    {
        public string AccessToken { get; set; }
        public string BaseUrl = "https://api-ssl.bitly.com/v4";
        private const string BearerAuthScheme = "Bearer";

        public Bitly(ShortenUrlOptions options)
        {
            AccessToken = options.Bitly["AccessToken"];
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public Bitly()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public async Task<string> GetShorten(IRequestParameters parameters)
        {
            string url = $"{BaseUrl}/shorten";
            
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                
                request.Headers.Authorization = new AuthenticationHeaderValue(BearerAuthScheme, AccessToken);
                using (var httpClient = new HttpClient())
                {
                    var res = await httpClient.SendAsync(request).ConfigureAwait(false);
                    res.EnsureSuccessStatusCode();
                    var resultJson = await res.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return resultJson;
                }
            }
        }

       
        
    }
}
