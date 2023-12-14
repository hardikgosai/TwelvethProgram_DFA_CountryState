using AutoMapper;
using Getri_DFA_CountryState.DTO;
using Getri_DFA_CountryState.Models;

namespace Getri_DFA_CountryState.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<CreateCountryDTO, Country>();
             CreateMap<UpdateCountryDTO, Country>().
                ForMember(d => d.Name, opt => opt.MapFrom(s=> s.CountryName));            
             CreateMap<CreateStateDTO, State>();
        }
    }
}
