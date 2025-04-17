using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GiaiDau, GiaiDauModel>().ReverseMap();
            CreateMap<DoiDau, DoiDauModel>().ReverseMap();
            CreateMap<ThanhVien, ThanhVienGiaiDauModel>().ReverseMap();
            CreateMap<ThanhVienGiaiDau, ThanhVienGiaiDauModel>().ReverseMap();
            //CreateMap<UserRegisterRequest, User>().ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => PasswordHasher.HashPassword(src.Password))).ReverseMap();
        }
    }
}
