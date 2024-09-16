using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientCities.Data.DbApplicationContext
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        public DbInitializer()
        {
           
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
