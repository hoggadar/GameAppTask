using GameAppTaskDataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<UserModel> AppUsers { get; set; }
        public DbSet<BoardGameModel> BoardGames { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
