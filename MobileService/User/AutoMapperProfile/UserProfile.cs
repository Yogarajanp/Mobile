using AutoMapper;
using MobileRepository.Base.DTO;

namespace MobileService.User.AutoMapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<MobileRepository.Model.User, UserDto>().ReverseMap();

        }
    }
}
