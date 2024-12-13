using GameAppTaskBusiness.DTOs.Comment;

namespace GameAppTaskBusiness.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllByGameId(string gameId);
        Task<CommentDto> Create(CreateCommentDto dto);
    }
}
