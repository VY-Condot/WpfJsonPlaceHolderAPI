using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfJsonPlaceHolderAPI.Interfaces;
using WpfJsonPlaceHolderAPI.Models;
using WpfJsonPlaceHolderAPI.Services;
using WpfJsonPlaceHolderAPI.Services.API;

namespace WpfJsonPlaceHolderAPI.ViewModels
{
    public class CommentViewModel : ObservableObject
    {
        public ObservableCollection<CommentModel> AllComments { get; set; }

        //private readonly ICommentApiService _commentApiService;
        //private readonly IApiDataCaching _apiDataCaching;

        public ICommand GetComments { get; private set; }

        public CommentViewModel()
        {
            //_apiDataCaching = new ApiDataCaching();
            //_commentApiService = new CommentApiService();
            AllComments = new ObservableCollection<CommentModel>();
            GetComments = new RelayCommand<object>(async obj => await GetAllComments());
        }

        private async Task GetAllComments()
        {
            AllComments.Clear();

            //var comments = await _commentApiService.GetAllCommentAsync();

            var comments = await ApiDataCaching.Instance.GetAllCommentAsync();

            //add into observable collection
            for(int i= 0;i<comments.Count; i++)
            {
                AllComments.Add(comments[i]);
            }
        }
    }
}
