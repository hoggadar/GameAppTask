using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class BoardGameRepository : Repository<BoardGameModel>, IBoardGameRepository
    {
        public BoardGameRepository(AppDbContext context) : base(context) { }

        public async Task<PaginatedResult<BoardGameModel>> GetAllByTitle(string title, int pageIndex, int pageSize)
        {
            var query = _context.BoardGames.Where(p => p.Title.Contains(title));
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResult<BoardGameModel>(items, pageSize, pageIndex, totalCount);
        }

        public async Task<BoardGameModel?> GetByTitle(string title)
        {
            var boardGame = await _context.BoardGames.FirstOrDefaultAsync(p => p.Title == title);
            return boardGame;
        }
    }
}
