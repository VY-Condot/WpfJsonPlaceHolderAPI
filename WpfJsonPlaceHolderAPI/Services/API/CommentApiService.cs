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
    internal class CommentApiService : ICommentApiService
    {
        public async Task<List<CommentModel>> GetAllCommentAsync()
        {
            string commentUrl = "https://jsonplaceholder.typicode.com/comments";

            using (HttpClient client = new())
            {
                var response = await client.GetStringAsync(commentUrl);

                //convert into models
                var comments = JsonSerializer.Deserialize<List<CommentModel>>(response,new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return comments;
            }
        }
    }
}
