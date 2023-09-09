using TestDotNet.Entities;
using TestDotNet.Repository.Interface;
using TestDotNet.Service.Interface;

namespace TestDotNet.Service.Implement
{
    public class WardService : Service<Ward>, IWardService
    {
        private readonly IWardRepository _wardRepository;

        public WardService(IWardRepository wardRepository) : base(wardRepository)
        {
            _wardRepository = wardRepository;
        }

        public IEnumerable<Ward> GetWardsByDistrictId(int districtId)
        {
            return _wardRepository.GetWardsByDistrictId(districtId);
        }
    }
}
