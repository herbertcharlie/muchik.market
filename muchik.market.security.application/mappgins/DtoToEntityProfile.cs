using AutoMapper;
using muchik.market.security.application.dto;
using muchik.market.security.domain.entities;

namespace muchik.market.security.application.mappgins
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
