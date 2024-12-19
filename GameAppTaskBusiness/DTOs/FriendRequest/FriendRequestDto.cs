using GameAppTaskBusiness.DTOs.Friend;

namespace GameAppTaskBusiness.DTOs.FriendRequest
{
    public class FriendRequestDto : FriendRequestBase
    {
        public string Id { get; set; } = null!;
        public bool IsAccepted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
