using TestDotNet.Entities;
using TestDotNet.Repository.Interface;
using TestDotNet.Service.Interface;

namespace TestDotNet.Service.Implement
{
    public class CityService : Service<City>, ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository) : base(cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<City> GetCitiesByName(string cityName)
        {
            return _cityRepository.GetCitiesByName(cityName);
        }
    }
}
