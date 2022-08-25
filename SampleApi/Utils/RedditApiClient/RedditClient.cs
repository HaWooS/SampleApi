using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestSharp;
using SampleApi.Models;
using SampleApi.Utils.Helpers;
using System.Text;

namespace SampleApi.Utils.RedditApiClient
{
    /// <summary>
    /// A client that provides communication to the Reddit API 
    /// </summary>
    public class RedditClient : IRedditClient
    {
        private static readonly string _redditApiUrl = "https://oauth.reddit.com/r/{subreddit}/hot?count=100&limit=100&show=all";
        private static readonly string _redditAuthUrl = "https://ssl.reddit.com/api/v1/access_token";
        private string _userName;
        private string _password;
        private string _redditAppClientId;
        private string _redditAppClientSecret;
        private string _subredditName;

        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        #region Constructor
        public RedditClient(string userName, string password, string redditAppClientId, string redditAppClientSecret, string subredditName)
        {
            _userName = userName;
            _password = password;
            _redditAppClientId = redditAppClientId;
            _redditAppClientSecret = redditAppClientSecret;
            _subredditName = subredditName;
        }
        #endregion

        #region RequestRedditApi

        /// <summary>
        /// Calls the Reddit API with the url specified in _redditApiUrl
        /// </summary>
        /// <returns> Generic response returned from the Reddit API </returns>
        public T RequestRedditApi<T>(RestSharp.Method methodType, IMemoryCache memoryCache) where T : RedditListingModel
        {
            try
            {
                //Get the API token from the memory cache
                string authToken = CacheManager.GetRedditApiTokenFromTheCache(memoryCache);
                if (string.IsNullOrEmpty(authToken))
                    authToken = this.Authenticate(memoryCache);

                RestClient restClient = new RestClient(_redditApiUrl);
                restClient.AddDefaultUrlSegment("subreddit", _subredditName);

                var request = new RestRequest() { Method = methodType };
                request.AddHeader("Authorization", $"Bearer {authToken}");
                request.AddParameter("limit", 500);
                request.AddParameter("count", 500);
                request.AddParameter("show", "all");

                var response = restClient.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("An error occurred during processing the request to the Reddit API");
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //If status is 401, try to authenticate and call the same request once again
                    authToken = this.Authenticate(memoryCache);
                    var parameter = request.Parameters.Where(p => p.Name == "Authorization").FirstOrDefault();
                    if (parameter is not null)
                    {
                        request.Parameters.RemoveParameter(parameter);
                        request.AddHeader("Authorization", $"Bearer {authToken}");
                    }

                    response = restClient.Execute(request);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                        throw new Exception("An error occurred during processing the request to the Reddit API");
                    else
                    {
                        return JsonConvert.DeserializeObject<T>(response.Content, _serializerSettings);
                    }
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(response.Content, _serializerSettings);
                }
            }
            catch (Exception ex)
            {
                throw;
                //log.LogInformation or log.LogError could be implemented here to trace the errors
            }
        }

        #endregion

        #region Authenticate

        //A method for receiving of the Reddit API user token
        public string Authenticate(IMemoryCache memoryCache)
        {
            RestClient restClient = new RestClient(_redditAuthUrl);
            var request = new RestRequest() { Method = Method.Post };

            var byteArray = Encoding.ASCII.GetBytes($"{_redditAppClientId}:{_redditAppClientSecret}");
            string encodeString = Convert.ToBase64String(byteArray);

            request.AddHeader("Authorization", $"Basic {encodeString}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", _userName);
            request.AddParameter("password", _password);

            var response = restClient.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("An error occurred during authentication process");
            else
            {
                var authModel = JsonConvert.DeserializeObject<RedditAuthModel>(response.Content, _serializerSettings);
                if (authModel != null && !string.IsNullOrEmpty(authModel.AccessToken))
                {
                    //Save newly received token in the memory cache
                    CacheManager.SaveRedditApiTokenInCache(authModel.AccessToken, memoryCache);
                    return authModel.AccessToken;
                }
                else
                    throw new Exception("An error occurred when parsing the token in the authentication process");
            }
        }

        #endregion

    }
}
