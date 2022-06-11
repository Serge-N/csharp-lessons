using AuthSample.Auth.Models;
using AuthSample.Resources;
using AutoMapper;

namespace AuthSample.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpResource, User>().ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
