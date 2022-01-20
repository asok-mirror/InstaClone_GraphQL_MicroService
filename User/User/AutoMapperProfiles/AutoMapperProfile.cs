using AutoMapper;
using User.Data.dtos;
using dataEntities = User.Data.entities;

namespace User.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<dataEntities.User, UserDTO>().ReverseMap();
        }
    }
}
