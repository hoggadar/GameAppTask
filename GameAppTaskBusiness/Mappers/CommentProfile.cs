using AutoMapper;
using GameAppTaskBusiness.DTOs.Comment;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentModel, CommentDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<CreateCommentDto, CommentModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => ParseGuid(src.UserId)))
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => ParseGuid(src.BoardGameId)))
                .ForMember(dest => dest.ParentCommentId, opt => opt.MapFrom(src => ParseNullableGuid(src.ParentCommentId)));

            CreateMap<CommentModel, CreateCommentDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.ToString()))
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.BoardGameId.ToString()))
                .ForMember(dest => dest.ParentCommentId, opt => opt.MapFrom(src => src.ParentCommentId.HasValue ? src.ParentCommentId.Value.ToString() : null));
        }

        private Guid ParseGuid(string input)
        {
            return Guid.TryParse(input, out Guid result) ? result : Guid.Empty;
        }

        private Guid? ParseNullableGuid(string input)
        {
            return string.IsNullOrEmpty(input) ? (Guid?)null : ParseGuid(input);
        }
    }
}
