using GameAppTaskDataAccess.Models;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IFavouriteRepository : IRepository<FavouriteModel>
    {
        Task<FavouriteModel?> GetByUserIdAndBoardGameId(string userId, string boardGameId);
    }
}
