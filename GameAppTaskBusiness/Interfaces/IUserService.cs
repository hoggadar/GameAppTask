using GameAppTaskBusiness.DTOs.User;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto?> GetById(string id);
        Task<UserDto?> Create(CreateUserDto dto);
        Task<UserDto?> Update(string id, UpdateUserDto dto);
        Task<UserModel?> Delete(string id);
    }
}
