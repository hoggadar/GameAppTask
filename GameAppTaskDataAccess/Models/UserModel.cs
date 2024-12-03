using Microsoft.AspNetCore.Identity;

namespace GameAppTaskDataAccess.Models
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
