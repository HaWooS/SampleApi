using Microsoft.Extensions.Caching.Memory;
using SampleApi.Models;

namespace SampleApi.Utils.RedditApiClient
{
    public interface IRedditClient
    {
        T RequestRedditApi<T>(RestSharp.Method methodType, IMemoryCache memoryCache) where T : RedditListingModel;
    }
}
