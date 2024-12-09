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
            IQueryable<UserModel> query = _context.CustomUsers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(email)) query = query.Where(p => p.Email.Contains(email));
            switch (sortParam)
            {
                case "FirstName":
                    query = query.OrderBy(p => p.FirstName);
                    break;
                case "LastName":
                    query = query.OrderBy(p => p.LastName);
                    break;
                default:
                    break;
            }
            _logger.LogInformation($"Skip: {(pageNumber - 1) * pageSize}, Take: {pageSize}");
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(p => p.Email)
                .ToListAsync();
            return new PaginatedResult<UserModel>(items, pageSize, pageNumber, totalCount);
        }
    }
}
