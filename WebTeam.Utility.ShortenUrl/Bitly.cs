using System;
using System.Collections.Generic;
using System.Text;

namespace WebTeam.Utility.ShortenUrl
{
    public class Bitly : IShortenUrl
    {
        public string ProviderName { get; set; }

        public string Get(string longUrl)
        {
            return "";
        }
    }
}
