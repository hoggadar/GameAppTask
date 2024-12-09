﻿using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

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
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedResult<UserModel>(items, pageSize, pageNumber, totalCount);
        }
    }
}
