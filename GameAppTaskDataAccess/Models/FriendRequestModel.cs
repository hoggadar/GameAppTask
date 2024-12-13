using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class FriendRequestModel
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("SenderId")]
        public Guid SenderId { get; set; }
        public UserModel Sender { get; set; } = null!;

        [ForeignKey("RecipientId")]
        public Guid RecipientId { get; set; }
        public UserModel Recipient { get; set; } = null!;
    }
}
