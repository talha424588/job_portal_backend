﻿using AutoMapper;
using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Models;

namespace JobPortal.Utils
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, RegisterRequestBody>().ReverseMap();

            CreateMap<User, RegisterResponseBody>().ReverseMap();

            CreateMap<User, LoginResponseBody>().ReverseMap();
            CreateMap<Employer, EmployerRequestBody>().ReverseMap();
            CreateMap<Employer,EmployerResponseBody>().ReverseMap();
        }
    }
}
