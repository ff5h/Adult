using Adult.API.Identity.BLL.DTOs;
using Adult.API.Models;
using AutoMapper;

namespace Adult.API.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<RegistrationRequest, RegistrationRequestDTO>();
            CreateMap<LoginRequest, LoginRequestDTO>();
            CreateMap<LoginResponse, LoginResponseDTO>();
        }
    }
}
