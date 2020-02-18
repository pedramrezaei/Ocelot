using Ocelot.Configuration.File;
using System.Linq;

namespace Ocelot.Cache
{
    public class RegionCreator : IRegionCreator
    {
        public string Create(FileReRoute reRoute)
        {
            if (!string.IsNullOrEmpty(reRoute?.FileCacheOptions?.Region))
            {
                return reRoute?.FileCacheOptions?.Region;
            }

            var methods = string.Join(string.Empty, reRoute.UpstreamHttpMethod.Select(m => m));

            var region = $"{methods}{reRoute.UpstreamPathTemplate.Replace("/", string.Empty)}";

            return region;
        }
    }
}
