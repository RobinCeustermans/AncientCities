using AncientCities.Data.DbApplicationContext;
using AncientCities.Data.Repository.Interfaces;
using AncientCities.Models;

namespace AncientCities.Data.Repository.Concrete
{
    public class CityImageRepository : Repository<CityImage>, ICityImageRepository
    {
        ApplicationDbContext _context;
        public CityImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CityImage cityImage)
        {
            _context.CityImages.Update(cityImage);
        }
    }
}
