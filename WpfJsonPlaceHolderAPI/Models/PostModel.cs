using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WpfJsonPlaceHolderAPI.Services;

namespace WpfJsonPlaceHolderAPI.Models
{
    public class PostModel : ObservableObject
    {
        private int _id;
        private int _userId;
        private string _title;
        private string _body;
        public int Id
        {
            get => _id;
            set { _id = value;OnPropertyChanged(nameof(Id)); }
        }
        public int UserId
        {
            get => _userId;
            set { _userId = value; OnPropertyChanged(nameof(UserId)); }
        }
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }
        public string Body
        {
            get => _body;
            set { _body = value; OnPropertyChanged(nameof(Body)); }
        }
    }
}
