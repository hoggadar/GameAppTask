using GameAppTaskDataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GameAppTaskDataAccess.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<UserModel> CustomUsers { get; set; }
        public DbSet<BoardGameModel> BoardGames { get; set; }
        public DbSet<FavouriteModel> Favourites { get; set; }
        public DbSet<FriendRequestModel> Friends { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FriendRequestModel>()
                .HasOne(fr => fr.Sender)
                .WithMany(u => u.Senders)
                .HasForeignKey(fr => fr.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FriendRequestModel>()
                .HasOne(fr => fr.Recipient)
                .WithMany(u => u.Recipients)
                .HasForeignKey(fr => fr.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
