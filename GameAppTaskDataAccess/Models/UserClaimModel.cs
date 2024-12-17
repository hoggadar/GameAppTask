using Microsoft.AspNetCore.Identity;

namespace GameAppTaskDataAccess.Models
{
    public class UserClaimModel : IdentityUserClaim<Guid>
    {
        public virtual UserModel User { get; set; }
    }
}
