using AncientCities.Models;

namespace AncientCities.Data.Repository.Interfaces
{
    public interface ICityImageRepository : IRepository<CityImage>
    {
        void Update (CityImage cityImage);
    }
}
