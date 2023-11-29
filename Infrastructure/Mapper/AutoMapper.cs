using AutoMapper;
using Domain.DTOs.EmployeeDto;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class AutoMapper:Profile
{
    public AutoMapper()
    {
        CreateMap<GetEmployeeDto, Employee>().ReverseMap();
        CreateMap<AddEmployeeDto, Employee>()
            .ForMember(em => em.Jobtitle, 
                opt => 
                    opt.MapFrom(em=>em.Jobtitle.ToString()));
        CreateMap<AddEmployeeDto, GetEmployeeDto>()
            .ForMember(em => em.Jobtitle, 
                opt => 
                    opt.MapFrom(em=>em.Jobtitle.ToString()));
    }
}