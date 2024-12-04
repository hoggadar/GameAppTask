using AutoMapper;
using GameAppTaskBusiness.DTOs.Favourite;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Mappers
{
    public class FavouriteProfile : Profile
    {
        public FavouriteProfile()
        {
            CreateMap<FavouriteBase, FavouriteModel>();
            CreateMap<FavouriteModel, FavouriteBase>();
        }
    }
}
