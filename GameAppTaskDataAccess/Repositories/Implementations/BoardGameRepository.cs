﻿using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Enums;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class BoardGameRepository : Repository<BoardGameModel>, IBoardGameRepository
    {
        public BoardGameRepository(AppDbContext context) : base(context) { }

        public async Task<PaginatedResult<BoardGameModel>> GetAllByTitleAndGenre(string title, GenreEnum? genre, int pageNumber, int pageSize)
        {
            IQueryable<BoardGameModel> query = _context.BoardGames.AsQueryable();
            if (!string.IsNullOrWhiteSpace(title)) query = query.Where(p => p.Title.Contains(title));
            if (genre.HasValue) query = query.Where(p => p.Genre == genre);
            var totalCount = await query.CountAsync();
            return await PaginatedResult<BoardGameModel>.CreateAsync(query, pageSize, pageNumber);
        }

        public async Task<IEnumerable<BoardGameModel>> GetAllByUserId(Guid id)
        {
            var boardGames = await _context.Favourites
                .Include(p => p.BoardGame)
                .Where(p => p.UserId == id)
                .Select(p => p.BoardGame)
                .ToListAsync();
            return boardGames;
        }

        public async Task<IEnumerable<BoardGameModel>> GetAllByGenre(GenreEnum genre)
        {
            var boardGames = await _context.BoardGames
                .Where(p => p.Genre == genre)
                .ToListAsync();
            return boardGames;
        }

        public async Task<BoardGameModel?> GetByTitle(string title)
        {
            var boardGame = await _context.BoardGames.FirstOrDefaultAsync(p => p.Title == title);
            return boardGame;
        }

        public async Task<BoardGameModel?> GetByIdWithComments(Guid id)
        {
            var boardGame = await _context.BoardGames
                .Include(p => p.Comments)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            return boardGame;
        }
    }
}
