using System;
using System.Collections.Generic;
using System.Text;

namespace WebTeam.Utility.ShortenUrl
{
   public class ShortenUrlOptions
    {
        public string Default { get; set; }

        public Dictionary<string, string> Bitly { get; set; }
        
    }
}
