﻿using AutoMapper;
using IfrsDocs.Domain;

namespace IfrsDocs.API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Form, FormDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}