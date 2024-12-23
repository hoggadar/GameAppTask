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
            CreateMap<FriendRequestModel, FriendRequestFullDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Recipient, opt => opt.MapFrom(src => src.Recipient));
            CreateMap<CreateFriendRequestDto, FriendRequestModel>()
                .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => ParseGuid(src.SenderId)))
                .ForMember(dest => dest.RecipientId, opt => opt.MapFrom(src => ParseGuid(src.RecipientId)));
        }

        private Guid ParseGuid(string input)
        {
            return Guid.TryParse(input, out Guid result) ? result : Guid.Empty;
        }
    }
}
