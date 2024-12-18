using AutoMapper;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameAppTaskBusiness.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<UserModel> userManager, IUserRepository userRepo, IMapper mapper, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _userRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<PaginatedResult<UserDto>> GetAllByParams(string email, string sortParam, int pageIndex, int pageSize)
        {
            var paginatedResult = await _userRepo.GetAllByParams(email, sortParam, pageIndex, pageSize);
            var users = _mapper.Map<IEnumerable<UserDto>>(paginatedResult.Items);
            return new PaginatedResult<UserDto>(users, pageSize, pageIndex, paginatedResult.TotalCount);
        }

        public async Task<UserDto> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                string message = $"User with ID = {id} not found.";
                _logger.LogWarning(message);
                throw new KeyNotFoundException(message);
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Create(CreateUserDto dto)
        {
            var newUser = _mapper.Map<UserModel>(dto);
            var result = await _userManager.CreateAsync(newUser, dto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                string message = $"User creation failed: {errors}";
                _logger.LogError(message);
                throw new InvalidOperationException(message);
            }
            await _userManager.AddToRoleAsync(newUser, "User");
            return _mapper.Map<UserDto>(newUser);
        }

        public async Task<UserDto> Update(string id, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            string message;
            if (user == null)
            {
                message = $"User with ID = {id} not found.";
                _logger.LogWarning(message);
                throw new KeyNotFoundException(message);
            }
            var userToUpdate = _mapper.Map(dto, user);
            var result = await _userManager.UpdateAsync(userToUpdate);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                message = $"User update failed: {errors}";
                _logger.LogError(message);
                throw new InvalidOperationException(message);
            }
            return _mapper.Map<UserDto>(userToUpdate);
        }

        public async Task<UserDto> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            string message;
            if (user == null)
            {
                message = $"User with ID = {id} not found.";
                _logger.LogWarning(message);
                throw new KeyNotFoundException(message);
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                message = $"User deletion failed: {errors}";
                _logger.LogError(message);
                throw new InvalidOperationException(message);
            }
            return _mapper.Map<UserDto>(user);
        }
    }
}
