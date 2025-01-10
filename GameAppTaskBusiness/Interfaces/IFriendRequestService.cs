using GameAppTaskBusiness.DTOs.FriendRequest;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IFriendRequestService
    {
        Task<IEnumerable<UserDto>> GetSubscriptionsByUserId(string userId);
        Task<IEnumerable<UserDto>> GetSubscribersByUserId(string userId);
        Task<IEnumerable<UserDto>> GetFriendsByUserId(string userId);
        Task<FriendRequestDto> SendFriendRequest(CreateFriendRequestDto dto);
        Task<FriendRequestDto> AcceptFriendRequest(string id);
    }
}
