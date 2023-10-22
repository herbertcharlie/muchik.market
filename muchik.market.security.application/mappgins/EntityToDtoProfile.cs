using AutoMapper;
using muchik.market.security.application.dto;
using muchik.market.security.domain.entities;

namespace muchik.market.security.application.mappgins
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, SignInResponseDto>();
        }
    }
}
