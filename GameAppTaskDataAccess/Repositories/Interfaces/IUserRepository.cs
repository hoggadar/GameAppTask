using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;

namespace GameAppTaskDataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserModel>
    {
        //Task<PaginatedResult<UserModel>> GetAllByParams(string email, string sortParam, int pageSize);
    }
}
