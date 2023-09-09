using TestDotNet.Entities;

namespace TestDotNet.Service.Interface
{
    public interface ICityService : IService<City>
    {
        IEnumerable<City> GetCitiesByName(string cityName);
    }

}
