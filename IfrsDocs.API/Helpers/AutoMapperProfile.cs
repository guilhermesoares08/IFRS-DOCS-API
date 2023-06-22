using AutoMapper;
using IfrsDocs.API.Dto;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Extensions;

namespace IfrsDocs.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Form, FormDto>()
                .ForMember(
                    dest => dest.Status,
                    opts => opts.MapFrom(src => src.Status.GetDescription()))
                .ForMember(
                    dest => dest.ReceiveDocumentType,
                    opts => opts.MapFrom(src => src.ReceiveDocumentType.GetDescription()))
                .ForMember(
                    dest => dest.DocumentType,
                    opts => opts.MapFrom(src => src.DocumentType.GetDescription()))
                .ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<Form, RequestNewFormDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(
                            dest => dest.Login,
                            opt => opt.MapFrom(src => src.Login))
                .ReverseMap();

            CreateMap<DocumentOption, DocumentOptionDto>().ForMember(
                    dest => dest.DocumentType,
                    opts => opts.MapFrom(src => new DocumentTypeDto
                    {
                        Id = (int)src.DocumentType,
                        Description = src.DocumentType.GetDescription()
                    }))
                .ReverseMap();
        }
    }


}
