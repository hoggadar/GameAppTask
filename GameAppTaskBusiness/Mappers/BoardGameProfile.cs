using AutoMapper;
using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Mappers
{
    public class BoardGameProfile : Profile
    {
        public BoardGameProfile()
        {
            CreateMap<BoardGameModel, BoardGameDto>();
            CreateMap<CreateBoardGameDto, BoardGameModel>();
            CreateMap<UpdateBoardGameDto, BoardGameModel>();
        }
    }
}
