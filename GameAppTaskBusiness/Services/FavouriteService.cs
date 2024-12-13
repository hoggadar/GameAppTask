using AutoMapper;
using GameAppTaskBusiness.DTOs.Favourite;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameAppTaskBusiness.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<FavouriteService> _logger;

        public FavouriteService(IFavouriteRepository favouriteRepo, IMapper mapper, ILogger<FavouriteService> logger)
        {
            _favouriteRepo = favouriteRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<FavouriteDto>> GetAll()
        {
            var favourites = await _favouriteRepo.GetAll();
            return _mapper.Map<IEnumerable<FavouriteDto>>(favourites);
        }

        public async Task<FavouriteDto?> GetByUserIdAndBoardGameId(string userId, string boardGameId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId) || !Guid.TryParse(boardGameId, out Guid parsedboardGameId))
            {
                string message = $"Incorrect Guid format userId: {userId}, boardGameId: {boardGameId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
                
            }
            var favourite = await _favouriteRepo.GetByUserIdAndBoardGameId(parsedUserId, parsedboardGameId);
            return _mapper.Map<FavouriteDto>(favourite);
        }

        public async Task<FavouriteDto> Create(CreateFavouriteDto dto)
        {
            var newFavourite = _mapper.Map<FavouriteModel>(dto);
            newFavourite.Id = Guid.NewGuid();
            var createdFavourite = await _favouriteRepo.Create(newFavourite);
            return _mapper.Map<FavouriteDto>(createdFavourite);
        }

        public async Task<FavouriteDto> Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid parsedId))
            {
                string message = $"Incorrect Guid format userId: {id}";
                _logger.LogWarning(message);
                throw new FormatException(message);
                
            }
            var favourite = await _favouriteRepo.GetById(parsedId);
            if (favourite == null)
            {
                string message = $"Favourite with ID = {id} not found.";
                _logger.LogWarning(message);
                throw new KeyNotFoundException(message);
            }
            var deletedFavourite = await _favouriteRepo.Delete(favourite);
            return _mapper.Map<FavouriteDto>(deletedFavourite);
        }
    }
}
