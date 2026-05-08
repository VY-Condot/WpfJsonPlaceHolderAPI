using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJsonPlaceHolderAPI.DataBase;
using WpfJsonPlaceHolderAPI.Interfaces;
using WpfJsonPlaceHolderAPI.Models;

namespace WpfJsonPlaceHolderAPI.Services
{
    public class PostSaveService : IPostSaveService
    {
        public async Task Save(PostModel Save)
        {
            using (var db = new AppDbContext())
            {
                db.Posts.Add(Save);

                await db.SaveChangesAsync();
            }
        }
    }
}
