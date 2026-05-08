using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfJsonPlaceHolderAPI.Models;

namespace WpfJsonPlaceHolderAPI.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        //public AppDbContext(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlite("Data Source = app.db");
        //}

        // 1. Add an empty constructor
        public AppDbContext() { }

        //2.add this constructor for flexibilty
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //3.overriding Onconfiguring method to set up the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //    base.OnConfiguring(optionsBuilder);
            //    optionsBuilder.UseSqlite("Data Source = app.db");

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source = app.db");
        }
    }
}
