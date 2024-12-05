using AutoMapper;
using GameAppTaskBusiness.DTOs.Auth;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskDataAccess.Models;

namespace GameAppTaskBusiness.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<CreateUserDto, UserModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<UpdateUserDto, UserModel>();
            CreateMap<UserDto, UpdateUserDto>();
            CreateMap<SignupDto, CreateUserDto>();
        }
    }
}
