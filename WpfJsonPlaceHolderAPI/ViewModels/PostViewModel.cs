
using System.Collections.ObjectModel;

using System.Windows.Input;
using WpfJsonPlaceHolderAPI.Interfaces;
using WpfJsonPlaceHolderAPI.Models;
using WpfJsonPlaceHolderAPI.Services;
using WpfJsonPlaceHolderAPI.Services.Cache;

namespace WpfJsonPlaceHolderAPI.ViewModels
{
    public class PostViewModel : ObservableObject
    {
        //get post collection from api service
        public ObservableCollection<PostModel> AllPosts { get; set; }
        //private readonly IPostApiService _postApiService;
        //private readonly IApiDataCaching _apiDataCaching;

        //buttons Commands
        public ICommand PostCommand { get; private set; }

        public PostViewModel()
        {
            //_apiDataCaching = new ApiDataCaching();
            //_postApiService = new PostApiService();
            AllPosts = new ObservableCollection<PostModel>();
            PostCommand = new RelayCommand<object>(async obj => await GetAllPosts());
        }

        //get post data from api and addto collection
        private async Task GetAllPosts()
        {
            AllPosts.Clear();

            //var posts = await _postApiService.GetAllPostsAsync();
            //var posts = await ApiDataCaching.Instance.GetAllPostsAsync();
            var posts = await RedisCache.Instance.GetAllPostsAsync();

            //add into collection
            for (int i= 0;i < posts.Count; i++)
            {
                AllPosts.Add(posts[i]);
            }
        }
    }
}
