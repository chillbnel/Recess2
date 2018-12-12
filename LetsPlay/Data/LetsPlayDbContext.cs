using LetsPlay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsPlay.Data
{
    public class LetsPlayDbContext : DbContext
    {
        public LetsPlayDbContext(DbContextOptions<LetsPlayDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendships>().HasKey(
                ce => new { ce.User1, ce.User2 }
                );

            modelBuilder.Entity<PlayerSignups>().HasKey(
                ce => new { ce.Username, ce.PostID }
                );
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Friendships> Friendships { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<PlayerSignups> Signups { get; set; }
        public DbSet<GeneralChat> GeneralChats { get; set; }
    }
}
