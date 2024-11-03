using AncientCities.Models;
using AutoMapper;
namespace AncientCities.Web.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, City>()
                .ForMember(dest => dest.CityImages, opt => opt.Ignore());
        }
    }
}
