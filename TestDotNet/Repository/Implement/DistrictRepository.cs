using TestDotNet.Entities;
using TestDotNet.Repository.Interface;

namespace TestDotNet.Repository.Implement
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<District> GetDistrictsByCityId(int cityId)
        {
            return _context.Districts.Where(d => d.CityId == cityId).ToList();
        }
    }
}
