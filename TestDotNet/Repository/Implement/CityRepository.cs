using Microsoft.EntityFrameworkCore;
using TestDotNet.Entities;
using TestDotNet.Repository.Interface;

namespace TestDotNet.Repository.Implement
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<City> GetCitiesByName(string cityName)
        {
            return _context.Cities.Where(c => c.Name.Contains(cityName)).ToList();
        }
    }
}
