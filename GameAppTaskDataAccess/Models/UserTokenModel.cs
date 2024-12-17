using Microsoft.AspNetCore.Identity;

namespace GameAppTaskDataAccess.Models
{
    public class UserTokenModel : IdentityUserToken<Guid>
    {
        public virtual UserModel User { get; set; }
    }
}
