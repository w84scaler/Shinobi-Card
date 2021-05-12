using System.Linq;

using AutoMapper;

using server.DTOs;
using server.Entities;
using server.Extensions;

namespace server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<User, UserDTO>()
            //    .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
            //        src.Photo.FirstOrDefault(p => p.IsMain).Url))
            //    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => 
            //        src.DateOfBirth.CalcAge()));


            //CreateMap<MemberUpdateDto,AppUser>();

            CreateMap<RegisterDTO, User>();
            CreateMap<User, GamerDTO>();

            CreateMap<Card, CardDTO>();
            //CreateMap<CardDTO, Card>();
            CreateMap<AddCardDTO, Card>();
        }
    }
}