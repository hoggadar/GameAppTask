using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IBoardGameRepository : IRepository<BoardGameModel>
    {
        Task<PaginatedResult<BoardGameModel>> GetAllByTitle(string title, int pageIndex, int pageSize);
        Task<BoardGameModel?> GetByTitle(string title);
    }
}
