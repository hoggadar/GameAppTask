using GameAppTaskDataAccess.Models;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<CommentModel>
    {
        Task<IEnumerable<CommentModel>> GetAllByGameId(Guid boardGameId);
    }
}
