using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJsonPlaceHolderAPI.ViewModels
{
    public class MainWindowViewModel
    {
        public PostViewModel PostView { get; }
        public CommentViewModel CommentView { get; }

        public MainWindowViewModel()
        {
            PostView = new PostViewModel();
            CommentView = new CommentViewModel();
        }

    }
}
