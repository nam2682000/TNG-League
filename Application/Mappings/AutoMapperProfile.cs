using Application.Models.GiaiDau;
using AutoMapper;
using Domain;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GiaiDau, GiaiDauModel>().ReverseMap();
            //CreateMap<UserRegisterRequest, User>().ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => PasswordHasher.HashPassword(src.Password))).ReverseMap();
        }
    }
}
