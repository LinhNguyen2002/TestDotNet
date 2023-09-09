using TestDotNet.Entities;
using TestDotNet.Repository.Interface;
using TestDotNet.Service.Interface;

namespace TestDotNet.Service.Implement
{
    public class DistrictService : Service<District>, IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository) : base(districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public IEnumerable<District> GetDistrictsByCityId(int cityId)
        {
            return _districtRepository.GetDistrictsByCityId(cityId);
        }
    }
}
