using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Models;

namespace WebNews.Data
{
    public class WebNewsContext : DbContext
    {
        public WebNewsContext(DbContextOptions<WebNewsContext> options) : base(options)
        {
        }


        #region Db Set

        public DbSet<News> News { set; get; }
        public DbSet<Group> Groups { set; get; }
        public DbSet<Media> Medias { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Comment> Comments { set; get; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Media>()
                .HasOne(m => m.News)
                .WithMany(n => n.Medias);

            modelBuilder.Entity<Media>()
                .HasOne(m => m.User)
                .WithOne(u => u.Media);

            base.OnModelCreating(modelBuilder);
        }
    }
}
