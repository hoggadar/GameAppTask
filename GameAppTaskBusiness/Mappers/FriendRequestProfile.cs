using AutoMapper;
using GameAppTaskBusiness.DTOs.FriendRequest;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Mappers
{
    public class FriendRequestProfile : Profile
    {
        public FriendRequestProfile()
        {
            CreateMap<FriendRequestModel, FriendRequestDto>();
            CreateMap<CreateFriendRequestDto, FriendRequestModel>();
        }
    }
}
