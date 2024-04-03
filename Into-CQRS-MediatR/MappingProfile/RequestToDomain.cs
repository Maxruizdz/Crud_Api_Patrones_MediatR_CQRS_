﻿using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;

namespace Into_CQRS_MediatR.MappingProfile
{
    public class RequestToDomain : Profile
    {


        public RequestToDomain() {

            CreateMap<CreateDriverAchievementRequest, Achievement>().
                ForMember(dest => dest.RaceWins,
                    opt => opt.MapFrom(src => src.Wins)).
                ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => 1)).
                ForMember(dest => dest.AddedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow)).
                ForMember(dest => dest.UpdateDate,
                        opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<UpdateDriverAchievementRequest, Achievement>().
                ForMember(dest => dest.RaceWins,
                    opt => opt.MapFrom(src => src.Wins)).
                ForMember(dest => dest.UpdateDate,
                        opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<CreateDriverRequest, Driver>().
                ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => 1)).
                ForMember(dest => dest.AddedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow)).
                ForMember(dest => dest.UpdateDate,
                        opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateDriverRequest, Driver>().
                ForMember(dest => dest.UpdateDate,
                        opt => opt.
                        MapFrom(src => DateTime.UtcNow)); 

        }


    }
}
