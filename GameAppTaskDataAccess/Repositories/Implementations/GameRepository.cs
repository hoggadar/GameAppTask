using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class GameRepository : Repository<BoardGameModel>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context) { }
    }
}
