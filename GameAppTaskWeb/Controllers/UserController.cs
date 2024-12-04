using AutoMapper;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserManager<UserModel> userManager, IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Info(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var createdUser = await _userService.Create(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var selectedUser = await _userService.GetById(id);
            var dto = _mapper.Map<UpdateUserDto>(selectedUser);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, UpdateUserDto dto)
        {
            var updatedUser = await _userService.Update(id, dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
