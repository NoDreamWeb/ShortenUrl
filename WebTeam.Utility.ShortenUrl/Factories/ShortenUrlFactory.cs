using System;
using System.Collections.Generic;
using System.Text;

namespace WebTeam.Utility.ShortenUrl
{
    /// <summary>
    /// Factory create all type shorten url.
    /// </summary>
    public static class ShortenUrlFactory
    {
        public static IShortenUrl Create(ShortenUrlOptions options)
        {
            switch (options.Default.ToLower())
            {
                case "bitly":
                    return new Bitly(options);
                default:
                    return null;
            }
        }
    }
}
