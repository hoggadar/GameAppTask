using AutoMapper;
using GameAppTaskBusiness.DTOs.Favourite;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;

namespace GameAppTaskBusiness.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepo;
        private readonly IMapper _mapper;

        public FavouriteService(IFavouriteRepository favouriteRepo, IMapper mapper)
        {
            _favouriteRepo = favouriteRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FavouriteDto>> GetAll()
        {
            var favourites = await _favouriteRepo.GetAll();
            return _mapper.Map<IEnumerable<FavouriteDto>>(favourites);
        }

        public async Task<FavouriteDto> Create(CreateFavouriteDto dto)
        {
            var newFavourite = _mapper.Map<FavouriteModel>(dto);
            var createdFavourite = await _favouriteRepo.Create(newFavourite);
            return _mapper.Map<FavouriteDto>(createdFavourite);
        }

        // TODO: fix mapper
        //public async Task<FavouriteDto?> Update(string id, UpdateFavouriteDto dto)
        //{
        //    var favourite = await _favouriteRepo.GetById(id);
        //    if (favourite == null) return null;
        //    var favouriteToUpdate = _mapper.Map<FavouriteModel>(favourite);
        //}

        public async Task<FavouriteDto?> Delete(string id)
        {
            var favourite = await _favouriteRepo.GetById(id);
            if (favourite == null) return null;
            var deletedFavourite = _favouriteRepo.Delete(favourite);
            return _mapper.Map<FavouriteDto>(deletedFavourite);
        }
    }
}
