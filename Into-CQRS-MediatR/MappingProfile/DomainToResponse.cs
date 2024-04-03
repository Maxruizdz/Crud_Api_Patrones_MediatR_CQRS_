using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;

namespace Into_CQRS_MediatR.MappingProfile
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {

            CreateMap<Achievement, DriverAchievementResponse>().
                ForMember(dest => dest.Wins,
                    opt => opt.MapFrom(src => src.RaceWins));


            CreateMap<Driver, GetDriverResponse>().ForMember(dest => dest.DriveId, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


        }





    }
}
