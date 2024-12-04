using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameAppTaskDataAccess.Models
{
    public class UserModel : IdentityUser
    {
        [MaxLength(32), MinLength(2)]
        public string FirstName { get; set; } = null!;
        
        [MaxLength(32), MinLength(2)]
        public string LastName { get; set; } = null!;

        public ICollection<FavouriteModel> Favourites { get; set; } = null!;
    }
}
