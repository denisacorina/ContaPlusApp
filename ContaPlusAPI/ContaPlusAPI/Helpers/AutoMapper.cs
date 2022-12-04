using AutoMapper;
using ContaPlusAPI.Models;

namespace ContaPlusAPI.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<User, UserDTO>().ReverseMap();        
            CreateMap<User, UserRegDTO>().ReverseMap();        
        }
    }
}
