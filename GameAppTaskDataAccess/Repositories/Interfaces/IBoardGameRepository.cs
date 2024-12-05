using GameAppTaskDataAccess.Enums;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IBoardGameRepository : IRepository<BoardGameModel>
    {
        Task<PaginatedResult<BoardGameModel>> GetAllByTitle(string title, int pageIndex, int pageSize);
        Task<IEnumerable<BoardGameModel>> GetAllByUserId(string id);
        Task<IEnumerable<BoardGameModel>> GetAllByGenre(GenreEnum genre);
        Task<BoardGameModel?> GetByTitle(string title);
    }
}
