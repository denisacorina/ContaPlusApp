using AutoMapper;
using ContaPlusAPI.Models;

namespace ContaPlusAPI.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<User, LoginUserDTO>().ReverseMap();        
            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<User, UserProfileUpdateDTO>().ReverseMap();

        }
    }
}
