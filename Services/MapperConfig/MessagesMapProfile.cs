using AutoMapper;
using Nh.Domain;
using Entities = Nh.Data.Entities;

namespace Nh.Services.MapperConfig
{
    public class MessagesMapProfile : Profile
    {
        public MessagesMapProfile()
        {
            CreateMap<Entities.Message, Message>();
            CreateMap<Message, Entities.Message>();
        }
    }
}
