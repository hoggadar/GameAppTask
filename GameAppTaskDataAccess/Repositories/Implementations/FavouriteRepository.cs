using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class FavouriteRepository : Repository<FavouriteModel>, IFavouriteRepository
    {
        public FavouriteRepository(AppDbContext context) : base(context) { }

        public async Task<FavouriteModel?> GetByUserIdAndBoardGameId(string userId, string boardGameId)
        {
            var favourite = await _context.Favourites.FirstOrDefaultAsync(p => p.UserId == userId && p.BoardGameId == boardGameId);
            return favourite;
        }
    }
}
