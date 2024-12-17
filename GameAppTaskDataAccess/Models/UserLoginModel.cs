using Microsoft.AspNetCore.Identity;

namespace GameAppTaskDataAccess.Models
{
    public class UserLoginModel : IdentityUserLogin<Guid>
    {
        public virtual UserModel User { get; set; }
    }
}
