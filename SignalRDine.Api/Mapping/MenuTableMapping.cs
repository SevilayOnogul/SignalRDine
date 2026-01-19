using AutoMapper;
using SignalRDine.DtoLayer.MenuTableDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Mapping
{
    public class MenuTableMapping:Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable,ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,UpdateMenuTableDto>().ReverseMap();
        }
    }
}
