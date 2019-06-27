using CoreGram.Data.Configurations;
using CoreGram.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                        .HasOne<UserProfile>(x => x.Profile)
                        .WithOne(x => x.User)
                        .HasForeignKey<UserProfile>(x => x.Id)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Follower>()
                        .ToTable("Followers")
                        .HasKey(x => new { x.UserId, x.FollowerId });

            modelBuilder.Entity<Follower>()
                        .HasOne<User>(x => x.UserFollower)
                        .WithMany(x => x.UserFollowers)
                        .HasForeignKey(x => x.FollowerId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follower>()
                        .HasOne<User>(x => x.UserFolling)
                        .WithMany(x => x.UserFollowings)
                        .HasForeignKey(x => x.UserId)
                        .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Post>()
            //            .ToTable("Posts")
            //            .HasKey(x => x.Id);

            //modelBuilder.Entity<Post>()
            //            .HasOne<User>(x => x.User)
            //            .WithMany(x => x.Posts)
            //            .HasForeignKey(x => x.UserId)
            //            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new PostConfiguration());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
