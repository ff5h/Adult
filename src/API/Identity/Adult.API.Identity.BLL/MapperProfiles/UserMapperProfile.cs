using Adult.API.Identity.BLL.DTOs;
using Adult.API.Identity.DAL.Entities;
using AutoMapper;

namespace Adult.API.Identity.BLL.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<GetUserResponseDTO, User>();
        }
    }
}
