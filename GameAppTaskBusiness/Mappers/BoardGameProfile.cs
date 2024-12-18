using AutoMapper;
using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskBusiness.DTOs.Comment;
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
            CreateMap<BoardGameDto, UpdateBoardGameDto>();

            CreateMap<BoardGameModel, BoardGameWithCommentsDto>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<CommentModel, CommentWithUserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.ParentCommentId, opt => opt.MapFrom(src => src.ParentCommentId.HasValue ? src.ParentCommentId.Value.ToString() : null));
        }
    }
}
