using AutoMapper;
using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameAppTaskBusiness.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<BoardGameService> _logger;

        public BoardGameService(IBoardGameRepository boardGameRepo, IMapper mapper, ILogger<BoardGameService> logger)
        {
            _boardGameRepo = boardGameRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<BoardGameDto>> GetAll()
        {
            var boardGames = await _boardGameRepo.GetAll();
            return _mapper.Map<IEnumerable<BoardGameDto>>(boardGames);
        }

        public async Task<IEnumerable<BoardGameDto>> GetAllByTitle(string title)
        {
            var boardGames = await _boardGameRepo.GetAllByTitle(title);
            return _mapper.Map<IEnumerable<BoardGameDto>>(boardGames);
        }

        public async Task<BoardGameDto?> GetById(string id)
        {
            var boardGame = await _boardGameRepo.GetById(id);
            if (boardGame == null) return null;
            return _mapper.Map<BoardGameDto>(boardGame);
        }

        public async Task<BoardGameDto?> GetByTitle(string title)
        {
            var boardGame = await _boardGameRepo.GetByTitle(title);
            if (boardGame == null) return null;
            return _mapper.Map<BoardGameDto>(boardGame);
        }

        public async Task<BoardGameDto> Create(CreateBoardGameDto dto)
        {
            var newBoardGame = _mapper.Map<BoardGameModel>(dto);
            var createdBoardGame = await _boardGameRepo.Create(newBoardGame);
            return _mapper.Map<BoardGameDto>(createdBoardGame);
        }

        public async Task<BoardGameDto?> Update(string id, UpdateBoardGameDto dto)
        {
            var boardGame = await _boardGameRepo.GetById(id);
            if (boardGame == null) return null;
            var boardGameToUpdate = _mapper.Map(dto, boardGame);
            var updatedBoardGame = await _boardGameRepo.Update(boardGameToUpdate);
            return _mapper.Map<BoardGameDto>(updatedBoardGame);
        }

        public async Task<BoardGameDto?> Delete(string id)
        {
            var boardGame = await _boardGameRepo.GetById(id);
            if (boardGame == null) return null;
            var deletedBoardGame = await _boardGameRepo.Delete(boardGame);
            return _mapper.Map<BoardGameDto>(deletedBoardGame);
        }
    }
}
