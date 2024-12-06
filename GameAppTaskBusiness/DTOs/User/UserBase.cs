using System.ComponentModel.DataAnnotations;

namespace GameAppTaskBusiness.DTOs.User
{
    public class UserBase
    {
        [Required]
        public string Email { get; set; } = null!;

        [MaxLength(32), MinLength(2)]
        public string FirstName { get; set; } = null!;

        [MaxLength(32), MinLength(2)]
        public string LastName { get; set; } = null!;
    }
}
