﻿namespace GameAppTaskBusiness.DTOs.Auth
{
    public class SignupDto : AuthBase
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
