using AutoMapper;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameAppTaskBusiness.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<UserModel> userManager, IMapper mapper, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> Create(CreateUserDto dto)
        {
            var newUser = _mapper.Map<UserModel>(dto);
            var result = await _userManager.CreateAsync(newUser, dto.Password);
            if (!result.Succeeded) return null;
            await _userManager.AddToRoleAsync(newUser, "User");
            return _mapper.Map<UserDto>(newUser);
        }

        public async Task<UserDto?> Update(string id, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;
            var userToUpdate = _mapper.Map(dto, user);
            var result = await _userManager.UpdateAsync(userToUpdate);
            if (!result.Succeeded) return null;
            return _mapper.Map<UserDto>(userToUpdate);
        }

        public async Task<UserModel?> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null) await _userManager.DeleteAsync(user);
            return user;
        }
    }
}
