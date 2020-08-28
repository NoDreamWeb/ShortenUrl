using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebTeam.Utility.ShortenUrl
{
    public interface IShortenUrl
    {
        Task<string> GetShorten(IRequestParameters parameters);
    }
}
