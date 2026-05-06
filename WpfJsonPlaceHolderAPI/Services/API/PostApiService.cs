using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfJsonPlaceHolderAPI.Interfaces;
using WpfJsonPlaceHolderAPI.Models;

namespace WpfJsonPlaceHolderAPI.Services.API
{
    public class PostApiService : IPostApiService
    {
        public async Task<List<PostModel>> GetAllPostsAsync()
        {
            string postUrl = "https://jsonplaceholder.typicode.com/posts";

            //using httpclient to get post data
            using (HttpClient client = new())
            {
                var response = await client.GetStringAsync(postUrl);

                //convert reponse to list of postmodel
                var posts = JsonSerializer.Deserialize<List<PostModel>>(response,new JsonSerializerOptions() { PropertyNameCaseInsensitive  = true });

                return posts;
            }
        }

        
    }
}
