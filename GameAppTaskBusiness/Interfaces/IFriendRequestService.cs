using GameAppTaskBusiness.DTOs.FriendRequest;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IFriendRequestService
    {
        Task<IEnumerable<FriendRequestDto>> GetAllBySenderId(string senderId);
        Task<IEnumerable<FriendRequestDto>> GetAllByRecipientId(string senderId);
        Task<IEnumerable<FriendRequestFullDto>> GetSubscriptionsBySenderId(string senderId);
        Task<IEnumerable<FriendRequestFullDto>> GetSubscribersBySenderId(string senderId);
        Task<IEnumerable<FriendRequestFullDto>> GetFriendsBySenderId(string senderId);
        Task<FriendRequestDto?> GetBySenderIdAndRecipientId(string senderId, string recipientId);
        Task<FriendRequestDto> SendFriendRequest(CreateFriendRequestDto dto);
        Task<FriendRequestDto> AcceptFriendRequest(string id);
    }
}
