using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<PaginatedResult<UserModel>> GetAllByParams(string email, string sortParam, int pageNumber, int pageSize)
        {
            IQueryable<UserModel> query = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(email)) query = query.Where(p => p.Email.Contains(email));
            switch (sortParam)
            {
                case "FirstNameAsc":
                    query = query.OrderBy(p => p.FirstName);
                    break;
                case "FirstNameDesc":
                    query = query.OrderByDescending(p => p.FirstName);
                    break;
                case "LastName":
                    query = query.OrderBy(p => p.LastName);
                    break;
                case "LastNameDesc":
                    query = query.OrderByDescending(p => p.LastName);
                    break;
                default:
                    query = query.OrderBy(p => p.Email);
                    break;
            }
            return await PaginatedResult<UserModel>.CreateAsync(query, pageSize, pageNumber);
        }
    }
}
