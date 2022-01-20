using AutoMapper;
using Post.Data.dtos;
using dataEntities = Post.Data.entities;

namespace Post.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<dataEntities.Post, PostDTO>().ReverseMap();
        }
    }
}
