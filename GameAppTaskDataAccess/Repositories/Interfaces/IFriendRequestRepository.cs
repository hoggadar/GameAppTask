using GameAppTaskDataAccess.Models;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IFriendRequestRepository : IRepository<FriendRequestModel>
    {
        Task<IEnumerable<FriendRequestModel>> GetAllBySenderId(Guid id);
        Task<IEnumerable<FriendRequestModel>> GetAllByRecipientId(Guid id);
        Task<IEnumerable<FriendRequestModel>> GetFriendsBySenderId(Guid id);
        Task<IEnumerable<FriendRequestModel>> GetRequestsBySenderId(Guid id);
        Task<FriendRequestModel?> GetBySenderIdAndRecipientId(Guid senderId, Guid recipientId);
    }
}
