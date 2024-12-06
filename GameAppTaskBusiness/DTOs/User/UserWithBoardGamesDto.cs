using GameAppTaskBusiness.DTOs.BoardGame;

namespace GameAppTaskBusiness.DTOs.User
{
    public class UserWithBoardGamesDto
    {
        public UserDto User { get; set; } = null!;
        public IEnumerable<BoardGameDto> BoardGames { get; set; } = null!;
    }
}
