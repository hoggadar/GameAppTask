using GameAppTaskDataAccess.Enums;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IBoardGameRepository : IRepository<BoardGameModel>
    {
        Task<PaginatedResult<BoardGameModel>> GetAllByTitleAndGenre(string title, GenreEnum? genre, int pageNumber, int pageSize);
        Task<IEnumerable<BoardGameModel>> GetAllByUserId(Guid id);
        Task<IEnumerable<BoardGameModel>> GetAllByGenre(GenreEnum genre);
        Task<BoardGameModel?> GetByTitle(string title);
        Task<BoardGameModel?> GetWithCommentsByGameId(Guid id);
    }
}
