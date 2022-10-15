using AutoMapper;

namespace Dummy.Profiles
{
    public class Regionsprofile:Profile
    {
        public Regionsprofile()
        {
            CreateMap<Models.Domain.Region,Models.DTO.Region>().ReverseMap();
        }

    }
}
