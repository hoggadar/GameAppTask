using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IBoardGameService
    {
        Task<IEnumerable<BoardGameDto>> GetAll();
        Task<PaginatedResult<BoardGameModel>> GetAllByTitle(string title, int pageIndex, int pageSize);
        Task<BoardGameDto?> GetById(string id);
        Task<BoardGameDto?> GetByTitle(string title);
        Task<BoardGameDto> Create(CreateBoardGameDto dto);
        Task<BoardGameDto?> Update(string id, UpdateBoardGameDto dto);
        Task<BoardGameDto?> Delete(string id);
    }
}
