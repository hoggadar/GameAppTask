using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class FriendRequestModel
    {
        [Key]
        public string Id { get; set; } = null!;

        public bool IsAccepted { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("SenderId")]
        public string SenderId { get; set; } = null!;
        public UserModel Sender { get; set; } = null!;

        [ForeignKey("RecipientId")]
        public string RecipientId { get; set; } = null!;
        public UserModel Recipient { get; set; } = null!;
    }
}
