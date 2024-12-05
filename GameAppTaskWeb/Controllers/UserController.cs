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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
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
            if (ModelState.IsValid)
            {
                var createdUser = await _userService.Create(dto);
                RedirectToAction("Index");
            }
            return View(dto);
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
            if (ModelState.IsValid)
            {
                var updatedUser = await _userService.Update(id, dto);
                RedirectToAction("Index");
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
