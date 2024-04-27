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
                    cfg.CreateMap<User, DtoUser>().MaxDepth(7);
                    cfg.CreateMap<Subsidiary, DtoSubsidiary>().MaxDepth(7);


                    cfg.CreateMap<DtoUser, User>().MaxDepth(7);
                    cfg.CreateMap<DtoSubsidiary, Subsidiary>().MaxDepth(7);
                });

                mapper = config.CreateMapper();

                _initMapper = false;
            }
        }
    }
}
