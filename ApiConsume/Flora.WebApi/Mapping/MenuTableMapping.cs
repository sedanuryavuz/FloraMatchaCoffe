using AutoMapper;
using Flora.DtoLayer.MenuTableDto;
using Flora.EntityLayer.Entities;

namespace Flora.WebApi.Mapping
{
    public class MenuTableMapping:Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable,ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,UpdateMenuTableDto>().ReverseMap();
        }
    }
}
