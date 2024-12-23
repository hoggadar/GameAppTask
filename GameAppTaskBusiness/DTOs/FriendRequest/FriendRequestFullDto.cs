using GameAppTaskBusiness.DTOs.User;

namespace GameAppTaskBusiness.DTOs.FriendRequest
{
    public class FriendRequestFullDto : FriendRequestDto
    {
        public UserDto Sender { get; set; } = null!;
        public UserDto Recipient { get; set; } = null!;
    }
}
