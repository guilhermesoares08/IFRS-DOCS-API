using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Extensions;

namespace IfrsDocs.API.Mappings
{
    public class CustomFormMapping : Profile
    {
        public CustomFormMapping()
        {
            CreateMap<Form, FormByUserDto>().ForMember(
                   dest => dest.Status,
                   opts => opts.MapFrom(src => src.Status.GetDescription()))
               .ForMember(
                   dest => dest.ReceiveDocumentType,
                   opts => opts.MapFrom(src => src.ReceiveDocumentType.GetDescription()))
               .ForMember(
                   dest => dest.DocumentType,
                   opts => opts.MapFrom(src => src.DocumentType.GetDescription()))
               .ReverseMap().ReverseMap();
        }
    }
}
