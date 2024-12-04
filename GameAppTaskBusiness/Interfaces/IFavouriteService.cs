using GameAppTaskBusiness.DTOs.Favourite;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IFavouriteService
    {
        Task<IEnumerable<FavouriteDto>> GetAll();
        Task<FavouriteDto> Create(CreateFavouriteDto dto);
        //Task<FavouriteDto?> Update(string id, UpdateFavouriteDto dto);
        Task<FavouriteDto?> Delete(string id);
    }
}
