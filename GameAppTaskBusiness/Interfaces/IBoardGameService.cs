using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskDataAccess.Enums;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IBoardGameService
    {
        Task<IEnumerable<BoardGameDto>> GetAll();
        Task<PaginatedResult<BoardGameModel>> GetAllByTitleAndGenre(string title, GenreEnum? genre, int pageIndex, int pageSize);
        Task<IEnumerable<BoardGameDto>> GetAllByUserId(string id);
        Task<IEnumerable<BoardGameDto>> GetAllByGenre(GenreEnum? genre);
        Task<BoardGameDto> GetById(string id);
        Task<BoardGameDto> GetByTitle(string title);
        Task<BoardGameWithCommentsDto> GetByIdWithComments(string id);
        Task<BoardGameDto> Create(CreateBoardGameDto dto);
        Task<BoardGameDto> Update(string id, UpdateBoardGameDto dto);
        Task<BoardGameDto> Delete(string id);
    }
}
