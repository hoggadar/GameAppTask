using AutoMapper;
using GameAppTaskBusiness.DTOs.Comment;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentModel, CommentDto>();
            CreateMap<CreateCommentDto, CommentModel>();
        }
    }
}
