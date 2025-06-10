using AutoMapper;
using Flora.DtoLayer.AboutDto;
using Flora.DtoLayer.EmployeeDto;
using Flora.EntityLayer.Entities;

namespace Flora.WebApi.Mapping
{
    public class AboutMapping:Profile
    {
        public AboutMapping()
        {
            CreateMap<About,ResultEmployeeDto>().ReverseMap();
            CreateMap<About, CreateEmployeeDto>().ReverseMap();
            CreateMap<About, UpdateEmployeeDto>().ReverseMap();
            CreateMap<About, GetEmployeeDto>().ReverseMap();
        }
    }
}
