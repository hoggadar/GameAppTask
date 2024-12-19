using GameAppTaskBusiness.DTOs.FriendRequest;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IFriendRequestService
    {
        Task<IEnumerable<FriendRequestDto>> GetAllBySenderId(string id);
        Task<IEnumerable<FriendRequestDto>> GetAllByRecipientId(string id);
        Task<IEnumerable<FriendRequestDto>> GetFriendsBySenderId(string id);
        Task<IEnumerable<FriendRequestDto>> GetRequestsBySenderId(string id);
        Task<FriendRequestDto?> GetBySenderIdAndRecipientId(string senderId, string recipientId);
        Task<FriendRequestDto> SendFriendRequest(CreateFriendRequestDto dto);
        Task<FriendRequestDto> AcceptFriendRequest(string id);
    }
}
