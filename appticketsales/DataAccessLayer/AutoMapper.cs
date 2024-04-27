using AutoMapper;
using DataAccessLayer.Entities;
using DataTransferLayer.Objects;

namespace DataAccessLayer
{
    public class AutoMapper
    {
        private static bool _initMapper = true;
        public static IMapper mapper;

        public static void start()
        {
            if (_initMapper)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, DtoUser>().MaxDepth(2);
                    cfg.CreateMap<Subsidiary, DtoSubsidiary>().MaxDepth(2);


                    cfg.CreateMap<DtoUser, User>().MaxDepth(2);
                    cfg.CreateMap<DtoSubsidiary, Subsidiary>().MaxDepth(2);


                    cfg.CreateMap<User, DtoAuthentication>().MaxDepth(1)
                        .ForMember(dest => dest.idUser, opt => opt.MapFrom(src => src.idUser))
                        .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.username))
                        .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password));
                });

                mapper = config.CreateMapper();

                _initMapper = false;
            }
        }
    }
}
