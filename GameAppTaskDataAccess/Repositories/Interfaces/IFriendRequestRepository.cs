using GameAppTaskDataAccess.Models;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IFriendRequestRepository : IRepository<FriendRequestModel>
    {
        Task<IEnumerable<UserModel>> GetSubscriptionsByUserId(Guid userId);
        Task<IEnumerable<UserModel>> GetSubscribersByUserId(Guid userId);
        Task<IEnumerable<UserModel>> GetFriendsByUserId(Guid userId);
        Task<FriendRequestModel?> GetBySenderIdAndRecipientId(Guid senderId, Guid recipientId);
    }
}
