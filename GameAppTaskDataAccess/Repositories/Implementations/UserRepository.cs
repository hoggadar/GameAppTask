using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
