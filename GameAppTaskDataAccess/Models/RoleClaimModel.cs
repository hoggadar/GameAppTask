using Microsoft.AspNetCore.Identity;

namespace GameAppTaskDataAccess.Models
{
    public class RoleClaimModel : IdentityRoleClaim<Guid>
    {
        public virtual RoleModel Role { get; set; }
    }
}
