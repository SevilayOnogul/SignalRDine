using AutoMapper;
using SignalRDine.DtoLayer.DiscountDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount,ResultDiscountDto>().ReverseMap();
            CreateMap<Discount,GetDiscountDto>().ReverseMap();
            CreateMap<Discount,CreateDiscountDto>().ReverseMap();
            CreateMap<Discount,UpdateDiscountDto>().ReverseMap();
        }
    }
}
