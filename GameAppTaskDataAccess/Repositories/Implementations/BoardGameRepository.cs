using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class BoardGameRepository : Repository<BoardGameModel>, IBoardGameRepository
    {
        public BoardGameRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<BoardGameModel>> GetAllByTitle(string title)
        {
            var boardGames = await _context.BoardGames.Where(p => p.Title.Contains(title)).ToListAsync();
            return boardGames;
        }

        public async Task<BoardGameModel?> GetByTitle(string title)
        {
            var boardGame = await _context.BoardGames.FirstOrDefaultAsync(p => p.Title == title);
            return boardGame;
        }
    }
}
