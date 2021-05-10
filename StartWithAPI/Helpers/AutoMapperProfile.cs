using AutoMapper;
using StartWithAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //automapping is onmogelijk om te debuggen! Zodoende zo weinig mogelijk functionaliteit in een mapping class.
            //Veel developers prefereren om automapping enkel te gebruiken om data van A naar B te brengen.

            CreateMap<AppUser, MemberDTO>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryOfOrigin))
            // property van destination vullen met data uit property van source; opt(ions) is steeds hetzelfde
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsProfilePicture).Url))
            //beter dan extension methods te gebruiken zoals in class AppUser (method GetAge() )
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
        }
    }
}
