using TestDotNet.Entities;
using TestDotNet.Repository.Interface;

namespace TestDotNet.Repository.Implement
{
    public class WardRepository : Repository<Ward>, IWardRepository
    {
        public WardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Ward> GetWardsByDistrictId(int districtId)
        {
            return _context.Wards.Where(w => w.DistrictId == districtId).ToList();
        }
    }
}
