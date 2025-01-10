using AutoMapper;
using GameAppTaskBusiness.DTOs.Auth;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Pagination;

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
            CreateMap<PaginatedResult<UserModel>, PaginatedResult<UserDto>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(src => src.CurrentPage))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));
        }
    }
}
