using StackExchange.Redis;
using System.Text.Json;
using System.Windows.Markup;
using WpfJsonPlaceHolderAPI.Interfaces;
using WpfJsonPlaceHolderAPI.Models;
using WpfJsonPlaceHolderAPI.Services.API;

namespace WpfJsonPlaceHolderAPI.Services.Cache
{
    public class RedisCache : IApiDataCaching
    {
        //resi interface 
        private readonly IDatabase _redisDatabase;
        private readonly IPostApiService postApiService;
        private readonly ICommentApiService commentApiService;

        private readonly string _redisConnectionString = "localhost:6379"; //string redis

        public static RedisCache Instance { get; } = new RedisCache();

        private RedisCache()
        {
            _redisDatabase = ConnectionMultiplexer.Connect(_redisConnectionString).GetDatabase();

            //intialize api service
            postApiService = new PostApiService();
            commentApiService = new CommentApiService();
        }

        public async Task<List<CommentModel>> GetAllCommentAsync()
        {
            string cacheKey = "Comments";

            //get key from redis
            var caches = await _redisDatabase.StringGetAsync(cacheKey);

            //if key exist
            if (caches.HasValue)
                return JsonSerializer.Deserialize<List<CommentModel>>(caches.ToString(),new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            //3.get data if redis not contains data
            var data = await commentApiService.GetAllCommentAsync();

            //4.set data to redis
            var serializeddata = JsonSerializer.Serialize(data);

            await _redisDatabase.StringSetAsync(cacheKey, serializeddata);
            return data;
        }

        public async Task<List<PostModel>> GetAllPostsAsync()
        {
            string strkey = "Posts";

            //1 check for data in redis
            var posts = await _redisDatabase.StringGetAsync(strkey);

            //3. check and return
            if(posts.HasValue)
                return JsonSerializer.Deserialize<List<PostModel>>(posts,new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;

            //4.get data from api 
            var postsData = await postApiService.GetAllPostsAsync();

            //add into redis
            var serializedData = JsonSerializer.Serialize(postsData);

            await _redisDatabase.StringSetAsync(strkey, serializedData);
            return postsData;
        }
    }
}
