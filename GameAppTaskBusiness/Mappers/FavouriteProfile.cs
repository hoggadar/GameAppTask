using AutoMapper;
using GameAppTaskBusiness.DTOs.Favourite;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Mappers
{
    public class FavouriteProfile : Profile
    {
        public FavouriteProfile()
        {
            CreateMap<FavouriteDto, FavouriteModel>();
            CreateMap<FavouriteModel, FavouriteDto>();
            CreateMap<CreateFavouriteDto, FavouriteModel>();
        }
    }
}
