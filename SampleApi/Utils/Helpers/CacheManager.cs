using Microsoft.Extensions.Caching.Memory;
using SampleApi.Models;

namespace SampleApi.Utils.Helpers
{
    /// <summary>
    /// Static cache manager for setting/getting objects in/from the memory cache
    /// </summary>
    public static class CacheManager
    {
        private static readonly string _tokenCacheKey = "TOKEN";

        #region GetRedditApiTokenFromTheCache

        //Get the Reddit API token from the cache
        public static string GetRedditApiTokenFromTheCache(IMemoryCache memoryCache)
        {
            memoryCache.TryGetValue(_tokenCacheKey, out string cachedToken);
            return cachedToken ?? string.Empty;
        }

        #endregion

        #region SaveRedditApiTokenInCache

        //Set the Reddit API token in the cache
        public static void SaveRedditApiTokenInCache(string token, IMemoryCache memoryCache)
        {
            string cachedToken = string.Empty;
            if (!memoryCache.TryGetValue(_tokenCacheKey, out cachedToken))
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.MaxValue).SetPriority(CacheItemPriority.NeverRemove);

                memoryCache.Set(_tokenCacheKey, cachedToken, cacheOptions);
            }
            else
            {
                cachedToken = token;
            }
        }

        #endregion

        #region SaveObjectIntoCache

        //Insert into the cache object of RandomImageModel
        public static void SaveObjectIntoCache(RandomImageModel randomImage, IMemoryCache memoryCache, string cacheKey)
        {
            List<RandomImageModel> cachedRandomGeneratedImageModelsList = null;
            if (!memoryCache.TryGetValue(cacheKey, out cachedRandomGeneratedImageModelsList))
            {
                cachedRandomGeneratedImageModelsList = new List<RandomImageModel>();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.MaxValue).SetPriority(CacheItemPriority.NeverRemove);

                cachedRandomGeneratedImageModelsList.Add(randomImage);

                memoryCache.Set(cacheKey, cachedRandomGeneratedImageModelsList.ToList(), cacheOptions);
            }
            else
            {
                cachedRandomGeneratedImageModelsList.Add(randomImage);
            }
        }

        #endregion

        #region LoadObjectsFromCache

        //Load from the cache a list of RandomImageModel type
        public static List<RandomImageModel> LoadObjectsFromCache(IMemoryCache memoryCache, string cacheKey)
        {
            if (memoryCache.TryGetValue(cacheKey, out var cacheObjects))
            {
                if (cacheObjects is List<RandomImageModel> cachedRandomGeneratedImageModelsList)
                {
                    return cachedRandomGeneratedImageModelsList;
                }
                else
                    return new List<RandomImageModel>();
            }
            else
                return new List<RandomImageModel>();
        }

        #endregion
    }
}
