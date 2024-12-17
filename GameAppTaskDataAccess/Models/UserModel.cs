using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class UserModel : IdentityUser<Guid>
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; } = null!;

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; } = null!;

        public ICollection<FavouriteModel> Favourites { get; set; } = null!;
        public ICollection<FriendRequestModel> Senders { get; set; } = null!;
        public ICollection<FriendRequestModel> Recipients { get; set; } = null!;

        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; } = null!;
        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; } = null!;
        public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; } = null!;
        public virtual ICollection<UserRoleModel> UserRoles { get; set; } = null!;
    }
}
