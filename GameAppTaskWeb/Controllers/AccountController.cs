using GameAppTaskBusiness.DTOs;
using GameAppTaskDataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupDto dto)
        {
            var newUser = new UserModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);
            if (result.Succeeded)
            {
                //await _userManager.AddToRoleAsync(newUser);
                return Ok();
            }

            return BadRequest("Invalid signup attemp");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest("Invalid login attempt");
        }
    }
}
