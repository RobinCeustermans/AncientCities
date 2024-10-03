using AncientCities.Data.DbApplicationContext;
using AncientCities.Data.Repository.Interfaces;
using AncientCities.Models;

namespace AncientCities.Data.Repository.Concrete
{
    public class CityTypeRepository : Repository<CityType>, ICityTypeRepository
    {
        private ApplicationDbContext _context;
        public CityTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}