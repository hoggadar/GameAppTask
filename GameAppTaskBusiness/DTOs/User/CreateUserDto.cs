namespace GameAppTaskBusiness.DTOs.User
{
    public class CreateUserDto : UserBase
    {
        public string Password { get; set; } = null!;
    }
}
