using AutoMapper;
using SignalRDine.DtoLayer.SliderDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Mapping
{
    public class SliderMapping:Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider,CreateSliderDto>().ReverseMap();
            CreateMap<Slider,UpdateSliderDto>().ReverseMap();
            CreateMap<Slider,ResultSliderDto>().ReverseMap();
            CreateMap<Slider, GetByIdSliderDto>().ReverseMap();
        }
    }
}
