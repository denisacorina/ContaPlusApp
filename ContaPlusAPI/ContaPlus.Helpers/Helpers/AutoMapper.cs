using AutoMapper;
using ContaPlusAPI.DTOs.AuthentificationDTO;
using ContaPlusAPI.DTOs.UserDTOs;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<User, LoginUserDTO>().ReverseMap();        
            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<User, UserProfileUpdateDTO>().ReverseMap();
            CreateMap<User, ResetPasswordDTO>().ReverseMap();
        }
    }
}
