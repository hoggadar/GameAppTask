using GameAppTaskDataAccess.Models;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IBoardGameRepository : IRepository<BoardGameModel>
    {
        Task<IEnumerable<BoardGameModel>> GetAllByTitle(string title);
        Task<BoardGameModel?> GetByTitle(string title);
    }
}
