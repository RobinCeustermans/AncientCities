using AncientCities.Data.DbApplicationContext;
using AncientCities.Models;

namespace AncientCities.Data.Repository.Interfaces
{
    public interface ICityTypeRepository : IRepository<CityType>
    {
        void Update(CityType cityType);
    }
}
