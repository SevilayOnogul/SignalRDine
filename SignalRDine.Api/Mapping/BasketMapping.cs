using AutoMapper;
using SignalRDine.DtoLayer.AboutDto;
using SignalRDine.DtoLayer.BasketDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Mapping
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<CreateBasketDto,Basket>().ReverseMap();
            CreateMap<ResultBasketListWithProducts,Basket>().ReverseMap();
        }
    }
}
