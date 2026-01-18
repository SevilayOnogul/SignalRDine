using AutoMapper;
using SignalRDine.DtoLayer.NotificationDto;
using SignalRDine.EntityLayer.Entities;

namespace SignalRDine.Api.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
        }

    }
}
