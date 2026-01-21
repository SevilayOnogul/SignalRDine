using AutoMapper;
using SignalRDine.DtoLayer.MessageDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto, Message>()
                .ForMember(dest => dest.MessageSendDate, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
        }
    }
}