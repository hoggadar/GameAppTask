using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class CommentRepository : Repository<CommentModel>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<CommentModel>> GetAllByGameId(Guid boardGameId)
        {
            var comments = await _context.Comments.Where(p => p.BoardGameId == boardGameId).ToListAsync();
            return comments;
        }

        public async Task<CommentModel?> GetLastByGameId(Guid boardGameId)
        {
            var comment = await _context.Comments
                .Where(p => p.BoardGameId == boardGameId)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();
            return comment;
        }
    }
}
