using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppTaskDataAccess.Models
{
    public class RoleModel : IdentityRole<Guid>
    {
        [Column(TypeName = "nvarchar(256)")]
        public string? Description { get; set; } = null!;
    }
}
