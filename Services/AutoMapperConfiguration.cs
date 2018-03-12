using AutoMapper;
using Nh.Services.MapperConfig;

namespace Nh.Services
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
             {
                 cfg.AddProfile<MessagesMapProfile>();
             });
        }
    }
}
