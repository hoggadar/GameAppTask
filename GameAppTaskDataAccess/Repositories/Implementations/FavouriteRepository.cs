using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class FavouriteRepository : Repository<FavouriteModel>, IFavouriteRepository
    {
        public FavouriteRepository(AppDbContext context) : base(context) { }
    }
}
