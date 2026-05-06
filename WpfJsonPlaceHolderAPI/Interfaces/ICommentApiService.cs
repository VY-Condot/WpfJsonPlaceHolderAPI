using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJsonPlaceHolderAPI.Models;

namespace WpfJsonPlaceHolderAPI.Interfaces
{
    public interface ICommentApiService
    {
        Task<List<CommentModel>> GetAllCommentAsync();
    }
}
