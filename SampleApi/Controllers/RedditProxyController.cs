using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SampleApi.Models;
using SampleApi.Utils.Helpers;
using SampleApi.Utils.Randomizer;
using SampleApi.Utils.RedditApiClient;

namespace SampleApi.Controllers
{
    [ApiController]
    public class RedditPictureProxyController : Controller
    {
        private readonly IRedditClient _redditClient;
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheKey = "CACHED_DRAWS";

        #region Constructor

        public RedditPictureProxyController(IRedditClient redditClient, IMemoryCache memoryCache)
        {
            _redditClient = redditClient;
            _memoryCache = memoryCache;
        }

        #endregion

        #region GetRandomRedditPictureByGivenSubredditName

        [Route("/random")]
        [HttpGet]
        public IActionResult GetRandomRedditPictureByGivenSubredditName()
        {
            try
            {
                var redditListingModel = _redditClient.RequestRedditApi<RedditListingModel>(RestSharp.Method.Get, _memoryCache);
                var top25SubredditsByUps = redditListingModel.data.children.Where(x => x.data != null && !string.IsNullOrEmpty(x.data.thumbnail)
                && x.data.thumbnail != "self" && !string.IsNullOrEmpty(x.data.ups)).OrderByDescending(x => x.data.ups).Take(25).Select(x => x.data).ToList();

                var randomSubreddit = RandomPictureGenerator.GetRandomSubredditChild(top25SubredditsByUps);
                if (randomSubreddit != null)
                {
                    CacheManager.SaveObjectIntoCache(randomSubreddit, _memoryCache, _cacheKey);
                    return Json(randomSubreddit);
                }
                else
                    return new NoContentResult();
            }
            catch (Exception ex)
            {
                //log.add communicate with the exception details
                return StatusCode(500, "Internal Server Error");
            }
            
        }

        #endregion

        #region GetImageDrawsHistory

        [Route("/history")]
        [HttpGet]
        public IActionResult GetImageDrawsHistory()
        {
            try
            {
                var cachedObjects = CacheManager.LoadObjectsFromCache(_memoryCache, _cacheKey);
                if (cachedObjects is null || cachedObjects.Count == 0)
                    return new NoContentResult();
                else
                    return Json(cachedObjects);
            }
            catch (Exception ex)
            {
                //log.add communicate with the exception details
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion
    }
}
