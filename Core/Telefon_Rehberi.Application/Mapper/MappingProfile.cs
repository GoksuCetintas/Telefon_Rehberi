using AutoMapper;
using Telefon_Rehberi.Application.ViewModels;
using Telefon_Rehberi.Domain.Entities;

namespace Telefon_Rehberi.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contact,ContactViewModel>().ReverseMap();
        CreateMap<Contact,ContactUpdateViewModel>().ReverseMap();
        CreateMap<Contact,ContactAddViewModel>().ReverseMap();
    }
}

