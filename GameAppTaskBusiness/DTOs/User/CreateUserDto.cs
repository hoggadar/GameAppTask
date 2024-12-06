using System.ComponentModel.DataAnnotations;

namespace GameAppTaskBusiness.DTOs.User
{
    public class CreateUserDto : UserBase
    {
        [Required]
        [MinLength(5)]
        public string Password { get; set; } = null!;
    }
}
