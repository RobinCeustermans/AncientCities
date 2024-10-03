using AncientCities.Models;

namespace AncientCities.Data.Repository.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        void Update(City city);
    }
}
