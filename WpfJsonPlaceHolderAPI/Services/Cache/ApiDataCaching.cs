using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJsonPlaceHolderAPI.Interfaces;
using WpfJsonPlaceHolderAPI.Models;
using WpfJsonPlaceHolderAPI.Services.API;

namespace WpfJsonPlaceHolderAPI.Services.Cache
{
    public class ApiDataCaching : IApiDataCaching
    {
        private readonly IMemoryCache _cache;
        private readonly IPostApiService _postApiService;
        private readonly ICommentApiService _commentApiService;

        public static ApiDataCaching Instance { get; } = new ApiDataCaching();

        public ApiDataCaching()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
            _postApiService = new PostApiService();
            _commentApiService = new CommentApiService();
        }

        public async Task<List<CommentModel>> GetAllCommentAsync()
        {
            return await _cache.GetOrCreateAsync("Comments", async entry => 
            {
                //set cache duration
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);

                //set priority to keep in cache
                entry.Priority = CacheItemPriority.Normal;

                //fetch data from api service
                return await _commentApiService.GetAllCommentAsync();
            });
        }

        public async Task<List<PostModel>> GetAllPostsAsync()
        {
            return await _cache.GetOrCreateAsync("Posts", async entry => 
            {
                //set cache duration
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);

                //set priority to keep in cache
                entry.Priority = CacheItemPriority.Normal;

                //fetch data from api service
                return await _postApiService.GetAllPostsAsync();
            });
        }
    }
}
