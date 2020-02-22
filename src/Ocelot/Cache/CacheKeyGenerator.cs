using Ocelot.Middleware;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Cache
{
    public class CacheKeyGenerator : ICacheKeyGenerator
    {
        public string GenerateRequestCacheKey(DownstreamContext context)
        {
            var builder = new StringBuilder("context.DownstreamRequest.Method");
            builder.Append('-');
            builder.Append(context.DownstreamRequest.OriginalString);
            if (context.DownstreamRequest.Content != null)
            {
                string requestContentString = Task.Run(async () => await context.DownstreamRequest.Content.ReadAsStringAsync()).Result;
                builder.Append(requestContentString);
            }

            return MD5Helper.GenerateMd5(builder.ToString());
        }
    }
}
