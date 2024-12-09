using GameAppTaskBusiness.DTOs.User;
using GameAppTaskDataAccess.Pagination;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<PaginatedResult<UserDto>> GetAllByParams(string email, string sortParam, int pageIndex, int pageSize);
        Task<UserDto> GetById(string id);
        Task<UserDto> Create(CreateUserDto dto);
        Task<UserDto> Update(string id, UpdateUserDto dto);
        Task<UserDto> Delete(string id);
    }
}
