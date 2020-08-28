using System;
using System.Collections.Generic;
using System.Text;

namespace WebTeam.Utility.ShortenUrl
{
    public class BitlyParams : IRequestParameters
    {
        public string long_url { get; set; }
    }
}
