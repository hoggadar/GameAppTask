using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameAppTaskDataAccess.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
        [MaxLength(32), MinLength(2)]
        public string FirstName { get; set; } = null!;
        
        [Required]
        [MaxLength(32), MinLength(2)]
        public string LastName { get; set; } = null!;

        public ICollection<FavouriteModel> Favourites { get; set; } = null!;
        public ICollection<FriendRequestModel> Senders { get; set; } = null!;
        public ICollection<FriendRequestModel> Recipients { get; set; } = null!;
    }
}
