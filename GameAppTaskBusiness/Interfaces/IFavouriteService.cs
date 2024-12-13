using GameAppTaskBusiness.DTOs.Favourite;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IFavouriteService
    {
        Task<IEnumerable<FavouriteDto>> GetAll();
        Task<FavouriteDto?> GetByUserIdAndBoardGameId(string userId, string boardGameId);
        Task<FavouriteDto> Create(CreateFavouriteDto dto);
        Task<FavouriteDto> Delete(string id);
    }
}
