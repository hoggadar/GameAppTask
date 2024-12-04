using GameAppTaskBusiness.DTOs.BoardGame;

namespace GameAppTaskBusiness.Interfaces
{
    public interface IBoardGameService
    {
        Task<IEnumerable<BoardGameDto>> GetAll();
        Task<IEnumerable<BoardGameDto>> GetAllByTitle(string title);
        Task<BoardGameDto?> GetById(string id);
        Task<BoardGameDto?> GetByTitle(string title);
        Task<BoardGameDto> Create(CreateBoardGameDto dto);
        Task<BoardGameDto?> Update(string id, UpdateBoardGameDto dto);
        Task<BoardGameDto?> Delete(string id);
    }
}
