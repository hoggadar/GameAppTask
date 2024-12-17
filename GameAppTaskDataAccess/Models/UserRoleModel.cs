using Microsoft.AspNetCore.Identity;

namespace GameAppTaskDataAccess.Models
{
    public class UserRoleModel : IdentityUserRole<Guid>
    {
        public virtual UserModel User { get; set; }
        public virtual RoleModel Role { get; set;}
    }
}
